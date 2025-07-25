using System.Collections;
using System.Drawing;
using UnityEngine;
namespace MyCharacterInput
{
    public class HealthPack : PickupManager
    {
        [SerializeField] private int HealAmount;
        [SerializeField] private AudioSource AudioSource1;
        [SerializeField] private GameObject Mesh;

        private float degreesPerSecond = 20.0f;
        private void Update()
        {
            Spin(Mesh,degreesPerSecond);
        }

        private void OnTriggerEnter(Collider other)
        {
            
            //Debug.Log(other);
            PlayerHealth pHealth = other.GetComponentInParent<PlayerHealth>();
            if (pHealth != null && pHealth.Health != pHealth.MaxHealth)
            {
                
                pHealth.OnHeal(HealAmount);
                ActivatePickup(other, AudioSource1);
                
            }
        }
    }
}

