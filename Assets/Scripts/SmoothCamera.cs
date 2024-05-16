using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{

    public float speed = 1.0f;
    public Transform target;        //  Object to follow by camera.

    //  This will be the focus on the camera. Camera will move so target is at offset related to camera
    public Vector3 offset;

    public Vector3 new_offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        new_offset = offset;
        new_offset.x = new_offset.x - (2 * new_offset.x);

    }

    // Update is called once per frame
    void Update()
    {
                //  Only if there is something to follow.
        if(target) {

            if(target.localScale.x == -1){

                Vector3 anchorPos = transform.position + new_offset;

                Vector3 movement = target.position - anchorPos;

                Vector3 newCamPos = transform.position + movement * speed * Time.deltaTime;
                transform.position = newCamPos;

            }else{
                //  Calculate where target should be related to camera.
                Vector3 anchorPos = transform.position + offset;
                //  Calculate camera so that relativ position of target will be ok.
                Vector3 movement = target.position - anchorPos;

                //  We only take a part of the distance. This will make movement "smooth".
                Vector3 newCamPos = transform.position + movement * speed * Time.deltaTime;
                transform.position = newCamPos;
            }

        }
    }
}
