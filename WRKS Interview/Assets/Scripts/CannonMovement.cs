using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Mathf.Abs(horizontalInput) > 0.1f)
        {
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f);
        }
}
}