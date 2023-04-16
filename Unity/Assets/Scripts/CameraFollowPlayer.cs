using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // camera will follow this object
    public Transform target;

    private Vector3 _cameraOffset;

    void Start()
    {
        _cameraOffset = transform.position - target.position;
    }
    
    private void LateUpdate()
    {
        Vector3 newPosition = target.position + _cameraOffset;
        transform.position = newPosition;
        //transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, SmoothTime);
    }
}
