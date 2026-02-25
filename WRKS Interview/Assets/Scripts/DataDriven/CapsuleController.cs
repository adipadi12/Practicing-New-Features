using Unity.Mathematics;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float frictionAmt = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private Rigidbody rb;
    private Camera mainCamera;
    private float horizontal;
    private float vertical;
    private float mouseX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if(movement.magnitude >= 0.1f)
        {
            rb.AddForce(movement * speed, ForceMode.Acceleration);
        }

        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        Vector3 frictionForce = -horizontalVelocity * frictionAmt;
        rb.AddForce(frictionForce, ForceMode.Acceleration);

        transform.Rotate(Vector3.up * mouseX * Time.fixedDeltaTime * rotationSpeed);
    }

    
}