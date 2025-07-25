using System.Collections;
using System.Drawing;
using UnityEngine;
namespace MyCharacterInput
{
    public class PickupManager : MonoBehaviour
    {
        //Spinning function
        public void Spin(GameObject pickup, float degreesPerSecond)
        {
            pickup.transform.Rotate(new Vector3(0, degreesPerSecond * Time.deltaTime, 0));
        }

        //On player touch, disable audio and destroy after delay so the sound can play
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

