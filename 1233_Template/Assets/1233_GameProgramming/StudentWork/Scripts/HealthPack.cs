using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
namespace MyCharacterInput
{
    public class HealthPack : PickupManager
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _medkitMesh;
        [SerializeField] private GameObject _pillsMesh;

        private GameObject _spinMesh;
        private int _healAmount;

        private float _degreesPerSecond = 20.0f;

        void Awake()
        {
            int randomNum = Random.Range(0, 2);
            switch (randomNum)
            {
                case 0:
                    _healAmount = 25;
                    _spinMesh = _pillsMesh;
                    _pillsMesh.SetActive(true);
                    break;
                case 1:
                    _healAmount = 50;
                    _spinMesh = _medkitMesh;
                    _medkitMesh.SetActive(true);
                    break;
            }
        }

        //call spin function in PickupManager
        void Update()
        {
            Spin(_spinMesh,_degreesPerSecond);
        }

        //heal player, activate pickup in PickupManager
        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other);
            PlayerHealth pHealth = other.GetComponentInParent<PlayerHealth>();
            if (pHealth != null && pHealth.Health != pHealth.MaxHealth)
            {
                
                pHealth.OnHeal(_healAmount);
                ActivatePickup(other, _audioSource);
            }
        }
    }
}

