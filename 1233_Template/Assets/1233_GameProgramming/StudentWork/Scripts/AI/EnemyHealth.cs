using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    public int Health;

    void Start()
    {
        Health = MaxHealth;
    }

    public void OnDMG(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
