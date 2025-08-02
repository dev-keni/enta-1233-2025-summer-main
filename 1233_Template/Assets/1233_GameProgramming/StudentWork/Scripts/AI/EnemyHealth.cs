using UnityEngine;
using UnityEngine.Serialization;

public class EnemyHealth : MonoBehaviour
{
    //THIS SCRIPT IS REPLACED BY AIPLAYERCONTROLLER
    [FormerlySerializedAs("MaxHealth")][SerializeField] private int _maxHealth;
    [SerializeField] private EnemyManager _enemyManager;
    public int Health;
    

    //Make sure enemy spawns with full health
    void Start()
    {
        Health = _maxHealth;
    }

    //On damage function, gets called when shot
    public void OnDMG(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    //Calls EnemyManager to spawn in a new enemy
    private void Die()
    {

        Destroy(gameObject);
    }
}
