using System.Collections;
using System.Drawing;
using UnityEngine;
namespace MyCharacterInput
{
    public class PickupManager : MonoBehaviour
    {
        public void Spin(GameObject pickup)
        {
            pickup.transform.Rotate(new Vector3(0, 1, 0));
        }

        public void ActivatePickup(Collider Touched, AudioSource audio)
        {
            StartCoroutine(PlayAudio(audio));
        }

        IEnumerator PlayAudio(AudioSource sound)
        {
            sound.Play();
            yield return new WaitForSecondsRealtime(0.3f);
            gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(1);
            Destroy(gameObject);
        }
    }
}

