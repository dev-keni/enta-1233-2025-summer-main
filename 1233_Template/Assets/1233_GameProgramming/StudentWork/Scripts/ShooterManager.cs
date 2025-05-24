using MyCharacterInput;
using UnityEngine;
namespace MyCharacterInput
{
    public class ShooterManager : MonoBehaviour
    {
        [SerializeField] private Camera Cam;

        [SerializeField] private GameObject BulletPrefab;

        [SerializeField] private MeInputs Inputs;

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
            Vector3 direction = Cam.transform.forward;

            Instantiate(BulletPrefab, Cam.transform.position, Cam.transform.rotation);
        }
    }
}

