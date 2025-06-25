using UnityEngine;
using MyCharacterInput;
namespace MyCharacterInput
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int MaxHealth;
        [SerializeField] private int Health;
        

        private void Awake()
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
}
