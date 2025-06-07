using UnityEngine;
using MyCharacterInput;
namespace MyCharacterInput
{
    public class PhysicsBullet : MonoBehaviour
    {
        [SerializeField] private float ProjectileSpeed;

        [SerializeField] private float ProjectileDmg;

        [SerializeField] private Rigidbody rb;

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

        void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.GetContact(0);
            shooterManager.OnProjectileCollision(contact.point, contact.normal);
            Destroy(gameObject);
        }

    }
}


