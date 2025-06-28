using System.Collections.Generic;
using UnityEngine;
namespace MyCharacterInput
{
    public class HealthPack : MonoBehaviour
    {
        [SerializeField] private int HealAmount;
        [SerializeField] private AudioSource AudioSource1;

        private void Update()
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0));
        }

        private void OnTriggerEnter(Collider other)
        {
            
            //Debug.Log(other);
            PlayerHealth pHealth = other.GetComponentInParent<PlayerHealth>();
            if (pHealth != null && pHealth.Health != pHealth.MaxHealth)
            {
                AudioSource1.Play();
                pHealth.OnHeal(HealAmount);
                Destroy(gameObject);
            }
        }
    }
}

