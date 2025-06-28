using UnityEngine;
using MyCharacterInput;
namespace MyCharacterInput
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int MaxHealth;
        [SerializeField] public int Health;
        [SerializeField] PlayerHUD PlayerHUD;
        

        private void Awake()
        {
            Health = MaxHealth;
        }
        public void OnDMG(int Damage)
        {
            Health -= Damage;
            PlayerHUD.OnHealthUpdated();
            if (Health <= 0)
            {
                Die();
            }
        }

        public void OnHeal(int Heal)
        {
            Health += Heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            PlayerHUD.OnHealthUpdated();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
