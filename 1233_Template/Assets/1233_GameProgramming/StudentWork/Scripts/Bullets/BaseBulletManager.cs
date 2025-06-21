using MyCharacterInput;
using UnityEngine;
namespace MyCharacterInput
{
    public class BaseBulletManager : MonoBehaviour
    {
        [SerializeField] private PhysicsBullet PhysicsBulletPrefab;
        [SerializeField] private GameObject BulletParticle;
        [SerializeField] private LayerMask RaycastMask;
        [SerializeField] private int Damage;
        private float timer;

        protected void SpawnPhysicsBullet(Transform shootersTransform)
        {
            // does not call collision until physics system collides

            PhysicsBullet spawnedbullet = Instantiate(PhysicsBulletPrefab, shootersTransform.position, shootersTransform.rotation);
            spawnedbullet.Initialize(this);
        }

        public void OnProjectileCollision(Vector3 pos, Vector3 rotation)
        {
            SpawnParticle(pos, rotation);
        }

        protected void DoRaycastShot(Transform camTransform)
        {
            LayerMask layerMask = LayerMask.GetMask("Wall", "Character");

            if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit, Mathf.Infinity, RaycastMask))
            {
                Debug.Log("Raycast Hit");
                AiPlayerController eHealth = hit.transform.gameObject.GetComponentInParent<AiPlayerController>();
                if (eHealth != null)
                {
                    eHealth.OnDMG(Damage);
                }
                OnProjectileCollision(hit.point, hit.normal);
            }
            else
            {
                Debug.Log("Raycast Miss");
            }
        }

        private void SpawnParticle(Vector3 pos, Vector3 ro)
        {
            Instantiate(BulletParticle, pos, Quaternion.Euler(ro));

        }
        
    }

}

