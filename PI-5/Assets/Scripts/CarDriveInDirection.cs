using UnityEngine;
using System.Collections;

public class CarDriveInDirection : MonoBehaviour
{

    private Rigidbody2D rb;
    private float hInput = 0.0f;
    private float vInput = 0.0f;

    public float speed = 200.0f;
    public float turnRate = 3.0f;

    Quaternion targetRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetRotation = Quaternion.identity;
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(hInput, vInput, 0);

        if (move.x != 0.0f || move.y != 0.0f)
        {
            targetRotation = Quaternion.LookRotation(Vector3.forward, move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate);
            rb.AddRelativeForce(Vector3.up * speed * Time.fixedDeltaTime);
        }
        // Get a left or right 90 degrees angle based on the rigidbody current rotation velocity
        float steeringRightAngle;
        if (rb.angularVelocity > 0)
        {
            steeringRightAngle = -90;
        }
        else
        {
            steeringRightAngle = 90;
        }
        // Find a Vector2 that is 90 degrees relative to the local forward direction (2D top down)
        Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * Vector2.up;
        // Calculate the 'drift' sideways velocity from comparing rigidbody forward movement and the right angle to this.
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));
        // Calculate an opposite force to the drift and apply this to generate sideways traction (aka tyre grip)
        Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);
        rb.AddForce(rb.GetRelativeVector(relativeForce));
    }
}