using UnityEngine;

public class Billboarding : MonoBehaviour
{
    //ensure camera is ready
    private Camera Cam;
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.forward = Cam.transform.forward;
    }
}
