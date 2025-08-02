using UnityEngine;
using MyCharacterInput;
namespace MyCharacterInput
{
    public class PlayerHealth : MonoBehaviour
    {
        
        [SerializeField] PlayerHUD PlayerHUD;

        public CharacterManager CharacterManager;
        public int MaxHealth;
        public int Health;

        //Set CharacterManager and make sure health is at its Max
        private void Awake()
        {
            Health = MaxHealth;
            CharacterManager = this.transform.parent.parent.GetComponent<CharacterManager>();
        }

        //Take damage function
        public void OnDMG(int Damage)
        {
            Health -= Damage;
            PlayerHUD.OnHealthUpdated();
            if (Health <= 0)
            {
                Die();
            }
        }

        //Heal player
        public void OnHeal(int Heal)
        {
            Health += Heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            PlayerHUD.OnHealthUpdated();
        }

        //Death activates menus
        private void Die()
        {
            CharacterManager.ResetMenu();
            Destroy(this.transform.parent.gameObject);
        }
    }
}
