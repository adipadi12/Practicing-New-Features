using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 700f;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject prjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody rb = prjectile.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce);
        }
    }
}
