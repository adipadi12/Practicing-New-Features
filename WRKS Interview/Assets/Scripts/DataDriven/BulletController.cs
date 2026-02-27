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

        StartCoroutine(DestroyBulletAfter(2f));
    }

    void OnTriggerEnter(Collider other)
    {
        if(shootEffect != null)
        {
            shootEffect.gameObject.SetActive(true);
            shootEffect.Play();    
        }

        StartCoroutine(DestroyBulletAfter(0.4f));
    }

    private IEnumerator DestroyBulletAfter(float bulletTime)
    {
        yield return new WaitForSeconds(bulletTime);
        Destroy(gameObject);
    }
}
