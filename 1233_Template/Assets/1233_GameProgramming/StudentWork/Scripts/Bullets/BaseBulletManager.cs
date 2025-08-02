using MyCharacterInput;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
namespace MyCharacterInput
{
    public class BaseBulletManager : MonoBehaviour
    {
        [FormerlySerializedAs("PhysicsBulletPrefab")][SerializeField] private PhysicsBullet _physicsBulletPrefab;
        [FormerlySerializedAs("BulletParticle")][SerializeField] private GameObject _bulletParticle;
        [FormerlySerializedAs("RaycastMask")][SerializeField] private LayerMask _raycastMask;
        [FormerlySerializedAs("Damage")][SerializeField] private int _damage;

        //Spawns physical bullet
        protected void SpawnPhysicsBullet(Transform shootersTransform)
        {
            // does not call collision until physics system collides

            PhysicsBullet spawnedBullet = Instantiate(_physicsBulletPrefab, shootersTransform.position, shootersTransform.rotation);
            spawnedBullet.Initialize(this);
        }

        //Projectile collision
        public void OnProjectileCollision(Vector3 pos, Vector3 rotation)
        {
            SpawnParticle(pos, rotation);
        }

        //Raycast weapon function
        protected void DoRaycastShot(Transform camTransform)
        {
            LayerMask layerMask = LayerMask.GetMask("Wall", "Character");

            if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit, Mathf.Infinity, _raycastMask))
            {
                //Debug.Log("Raycast Hit");
                AiPlayerController eHealth = hit.transform.gameObject.GetComponentInParent<AiPlayerController>();
                if (eHealth != null)
                {
                    eHealth.OnDMG(_damage);
                }
                OnProjectileCollision(hit.point, hit.normal);
            }
            else
            {
                //Debug.Log("Raycast Miss");
            }
        }

        //Spawn particle function, delay deleting with coroutine so the particle has time to play
        public void SpawnParticle(Vector3 pos, Vector3 ro)
        {
            GameObject particle = Instantiate(_bulletParticle, pos, Quaternion.Euler(ro));
            if (particle != null)
            {
                StartCoroutine(CleanParticle(particle));
            }
        }

        IEnumerator CleanParticle(GameObject particle)
        {
            if (particle != null)
            {
                yield return new WaitForSecondsRealtime(1);
                Destroy(particle);
            }
            
        }

    }

}

