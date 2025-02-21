using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
