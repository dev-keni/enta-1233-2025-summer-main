using UnityEngine;
using MyCharacterInput;
namespace MyCharacterInput
{
    public class PhysicsBullet : MonoBehaviour
    {
        [SerializeField] private float ProjectileSpeed;

        [SerializeField] private int ProjectileDmg;

        [SerializeField] private Rigidbody rb;

        [SerializeField] private LayerMask RaycastMask;

        private BaseBulletManager shooterManager;

        private bool _hasHit = false;

        public void Initialize(BaseBulletManager manager)
        {
            shooterManager = manager;
        }

        void Start()
        {
            //Add force on projectile spawn
            rb.AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other) //FOR MY OWN REFERENCE, NOT IN USE
        {
            if (_hasHit) return; 

            shooterManager.SpawnParticle(transform.position, transform.rotation.eulerAngles);
            AiPlayerController eHealth = other.GetComponentInParent<AiPlayerController>();
            if (eHealth != null)
            {
                _hasHit = true;
                eHealth.OnDMG(ProjectileDmg);
            }
            PlayerHealth pHealth = other.GetComponentInParent<PlayerHealth>();
            if (eHealth != null)
            {
                _hasHit = true;
                pHealth.OnDMG(ProjectileDmg);
            }
            Destroy(gameObject);

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_hasHit) return;
            //Debug.Log(collision.collider);
            shooterManager.SpawnParticle(transform.position, transform.rotation.eulerAngles);
            AiPlayerController eHealth = collision.collider.GetComponentInParent<AiPlayerController>();
            if (eHealth != null)
            {
                _hasHit = true;
                eHealth.OnDMG(ProjectileDmg);
            }
            PlayerHealth pHealth = collision.collider.GetComponentInParent<PlayerHealth>();
            if (pHealth != null)
            {
                _hasHit = true;
                pHealth.OnDMG(ProjectileDmg);
            }


            Destroy(gameObject);
        }

    }
}


