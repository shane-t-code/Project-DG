using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timeToDestroy;
    public Gun gun;

    private void Start()
    {
        gun = GetComponent<Gun>();
    }

    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment") || collision.gameObject.CompareTag("GoldenEgg") || collision.gameObject.CompareTag("EggCollectible"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            Target target = collision.transform.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(10);
            }
        }
    }
}
