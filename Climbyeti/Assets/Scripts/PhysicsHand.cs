using System;
using UnityEngine;

public class PhysicsHand : MonoBehaviour
{
    [Header("PID")] 
    [SerializeField] private float frequency = 50f;
    [SerializeField] private float damping = 1f;
    [SerializeField] private float rotFrequency = 100f;
    [SerializeField] private float rotDamping = 0.9f;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] private Transform target;
    private Rigidbody rigidbody;

    [Space] 
    [Header("Springs")] 
    [SerializeField] private float climbForce = 1000f;
    [SerializeField] private float climbDrag = 500f;

    private Vector3 previousPosition;
    private bool isColliding;
    
    private void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = float.PositiveInfinity;
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        PIDMovement();
        PIDRotation();
        if(isColliding) HookesLaw();
    }

    void PIDMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5f * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target.position - transform.position) * ksg +
                        (playerRigidbody.velocity - rigidbody.velocity) * kdg;
        rigidbody.AddForce(force, ForceMode.Acceleration);
    }

    void PIDRotation()
    {
        float kp = (6f * rotFrequency) * (6f * rotFrequency) * 0.25f;
        float kd = 4.5f * rotFrequency * rotDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Quaternion q = target.rotation * Quaternion.Inverse(transform.rotation);
        if (q.w < 0)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        q.ToAngleAxis(out float angle, out Vector3 axis);
        axis.Normalize();
        axis *= Mathf.Deg2Rad;
        Vector3 torque = ksg * axis * angle + -rigidbody.angularVelocity * kdg;
        rigidbody.AddTorque(torque, ForceMode.Acceleration);
    }

    void HookesLaw()
    {
        Vector3 displacementFromResting = transform.position - target.position;
        Vector3 force = displacementFromResting * climbForce;
        float drag = GetDrag();
        
        playerRigidbody.AddForce(force, ForceMode.Acceleration);
        playerRigidbody.AddForce(drag * -playerRigidbody.velocity * climbDrag, ForceMode.Acceleration);
    }

    float GetDrag()
    {
        Vector3 handVelocity = (target.localPosition - previousPosition / Time.fixedDeltaTime);
        float drag = 1 / handVelocity.magnitude + 0.01f;
        drag = drag > 1 ? 1 : drag;
        drag = drag < 0.03f ? 0.03f : drag;
        previousPosition = transform.position;
        return drag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }
}
