using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed;

    private Vector3 targetPos, newPos;
    public Vector3 minPos, maxPos;
    


    // Start is called before the first frame update
    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            targetPos = player.position;

            Vector3 camBounderyPos = new Vector3(

                Mathf.Clamp(targetPos.x, minPos.x, maxPos.x),
                Mathf.Clamp(targetPos.y, minPos.y, maxPos.y),
                Mathf.Clamp(targetPos.z, minPos.z, maxPos.z));

            newPos = Vector3.Lerp(transform.position, camBounderyPos, smoothSpeed);
            transform.position = newPos;
                
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
