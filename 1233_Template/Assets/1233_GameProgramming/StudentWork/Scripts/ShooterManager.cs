//using System.Numerics;
using System;
//using System.Numerics;
using MyCharacterInput;
using UnityEngine;
namespace MyCharacterInput
{
    public class ShooterManager : MonoBehaviour
    {
        [SerializeField] private Camera Cam;

        [SerializeField] private PhysicsBullet BulletPrefab;

        [SerializeField] private GameObject BulletParticle;

        [SerializeField] private MeInputs Inputs;

        [SerializeField] private LayerMask RaycastMask;

        [SerializeField] private ShootType ShootingCalculation;

        private PhysicsBullet physicsBullet;

        public void Initialize(PhysicsBullet manager)
        {
            physicsBullet = manager;
        }

        public enum ShootType
        {
            Raycast = 0,
            Physics = 1,
        }

        private void Update()
        {
            if (Inputs.Aim && Inputs.Shoot)
            {
                OnFirePressed();
            }
            Inputs.Shoot = false;

        }

        private void OnFirePressed()
        {
            switch (ShootingCalculation)
            {
                case ShootType.Raycast:
                    DoRaycastShot();
                    break;
                case ShootType.Physics:
                    SpawnPhysicsBullet();
                    break;
                default:
                    Debug.Log("ERROR");
                    break;
            }
        }

        private void SpawnPhysicsBullet()
        {
            // does not call collision until physics system collides

            PhysicsBullet spawnedbullet = Instantiate(BulletPrefab, Cam.transform.position, Cam.transform.rotation);
            spawnedbullet.Initialize(this);
        }

        private void DoRaycastShot()
        {
            LayerMask layerMask = LayerMask.GetMask("Wall", "Character");

            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Mathf.Infinity, RaycastMask))
            {
                OnProjectileCollision(hit.point, hit.normal);
            }
        }

        public void OnProjectileCollision(Vector3 pos, Vector3 rotation)
        {
            

            SpawnParticle(pos, rotation);
        }

        private void SpawnParticle(Vector3 pos, Vector3 ro)
        {
            Instantiate(BulletParticle, pos, Quaternion.Euler(ro));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (Inputs.Aim)
            {
                Gizmos.DrawLine(Cam.transform.position, Cam.transform.position + Cam.transform.forward * 100);
            }
        }

        private void CleanupParticle()
        {

        }
    }
}

