using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform cannonTransform;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float stopDistance = 4f;

    void Awake()
    {
        if(cannonTransform == null)
        {
            GameObject cannon = GameObject.FindWithTag("Player");
            if(cannon != null)
            {
                cannonTransform = cannon.transform;
            }
        }
    }

    void Update()
    {
        // Move towards the cannon
        Vector3 direction = cannonTransform.position - transform.position;
        if (direction.magnitude > stopDistance)
        {
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }
    }

}
