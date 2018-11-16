using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_Skeleton : MonoBehaviour {
    public Transform target;
    public Vector3 offset;
    public bool useOffset;
    public float rotateSpeed;

    // Use this for initialization
    void Start()
    {
        if (!useOffset)
        {
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") *10;
        target.Rotate(0, horizontal, 0);
    }
}
