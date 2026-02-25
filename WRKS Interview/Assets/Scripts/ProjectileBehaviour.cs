using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        EnemyMovement enemy = collision.gameObject.GetComponent<EnemyMovement>();
        if(enemy != null)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
