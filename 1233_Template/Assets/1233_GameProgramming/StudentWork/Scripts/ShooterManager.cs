//using System.Numerics;
using System;
//using System.Numerics;
using MyCharacterInput;
using UnityEngine;
namespace MyCharacterInput
{
    public class ShooterManager : BaseBulletManager
    {
        [SerializeField] private Camera Cam;

        [SerializeField] private MeInputs Inputs;

        [SerializeField] private ShootType ShootingCalculation;

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
                    DoRaycastShot(Cam.transform);
                    break;
                case ShootType.Physics:
                    SpawnPhysicsBullet(Cam.transform);
                    break;
                default:
                    Debug.Log("ERROR");
                    break;
            }
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

