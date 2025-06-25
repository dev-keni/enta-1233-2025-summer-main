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

        private bool hasHit = false;

        public void Initialize(BaseBulletManager manager)
        {
            shooterManager = manager;
        }

        void Start()
        {
            //Add force on projectile spawn
            rb.AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (hasHit) return; 

            shooterManager.SpawnParticle(transform.position, transform.rotation.eulerAngles);
            AiPlayerController eHealth = other.GetComponentInParent<AiPlayerController>();
            if (eHealth != null)
            {
                hasHit = true;
                eHealth.OnDMG(ProjectileDmg);
            }
            PlayerHealth pHealth = other.GetComponentInParent<PlayerHealth>();
            if (eHealth != null)
            {
                hasHit = true;
                pHealth.OnDMG(ProjectileDmg);
            }
            Destroy(gameObject);

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (hasHit) return;
            Debug.Log(collision.collider);
            shooterManager.SpawnParticle(transform.position, transform.rotation.eulerAngles);
            AiPlayerController eHealth = collision.collider.GetComponentInParent<AiPlayerController>();
            if (eHealth != null)
            {
                hasHit = true;
                eHealth.OnDMG(ProjectileDmg);
            }
            PlayerHealth pHealth = collision.collider.GetComponentInParent<PlayerHealth>();
            if (pHealth != null)
            {
                hasHit = true;
                pHealth.OnDMG(ProjectileDmg);
            }


            Destroy(gameObject);
        }

    }
}


