using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelCameraFollow : MonoBehaviour
{
    public Transform pixelCamera;

    public Transform spriteTransform;

    public float spriteWidth;

    public bool frameStutter = false;

    public int frames = 10;
    int i;
    
    // Start is called before the first frame update
    void Start()
    {
        i = frames + 1;
        Debug.Log(spriteWidth);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (frameStutter) {
            if (i > frames) {
                pixelCamera.GetComponent<Camera>().enabled = true;
                i = 0;
            }
            else {
                pixelCamera.GetComponent<Camera>().enabled = false;
            }
            i++;
        }
        spriteTransform.forward = spriteTransform.position - transform.position;
        pixelCamera.forward = spriteTransform.position - transform.position;
        pixelCamera.GetComponent<Camera>().fieldOfView = Mathf.Atan2(spriteWidth, (pixelCamera.transform.position - spriteTransform.position).magnitude) * 2f* Mathf.Rad2Deg;
        
    }
}
