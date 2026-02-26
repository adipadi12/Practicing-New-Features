using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private ParticleSystem shootEffect;
    void Awake()
    {
        if(shootEffect == null)
        {
            shootEffect = GetComponentInChildren<ParticleSystem>();
        }

        if(shootEffect != null)
        {
            shootEffect.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(shootEffect != null)
        {
            shootEffect.gameObject.SetActive(true);
            shootEffect.Play();    
        }

        StartCoroutine(DestroyBulletAfter());
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     if(shootEffect != null)
    //     {
    //         shootEffect.gameObject.SetActive(true);
    //         shootEffect.Play();    
    //     }

    //     StartCoroutine(DestroyBulletAfter());
    // }

    private IEnumerator DestroyBulletAfter()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
