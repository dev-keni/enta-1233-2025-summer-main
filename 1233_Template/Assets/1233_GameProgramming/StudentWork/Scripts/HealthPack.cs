using System.Collections;
using System.Drawing;
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
                
                pHealth.OnHeal(HealAmount);
                StartCoroutine(PlayAudio());
                
            }
        }

        IEnumerator PlayAudio()
        {
            AudioSource1.Play();
            yield return new WaitForSecondsRealtime(0.3f);
            gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(1);
            Destroy(gameObject);
        }
    }
}

