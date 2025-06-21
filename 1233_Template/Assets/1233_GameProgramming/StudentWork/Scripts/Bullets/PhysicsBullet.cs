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
            AiPlayerController eHealth = other.GetComponentInParent<AiPlayerController>();
            if (eHealth != null)
            {
                eHealth.OnDMG(ProjectileDmg);
                shooterManager.OnProjectileCollision(transform.position, transform.rotation.eulerAngles);
                Destroy(gameObject);
            }
            
        }

        void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.GetContact(0);
            Debug.Log(contact);
            shooterManager.OnProjectileCollision(contact.point, contact.normal);
            //Destroy(gameObject);
        }

    }
}


