using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        movementCamera();
    }

    void movementCamera(){
        Vector3 startPosition = new Vector3(target.position.x, target.position.y, -1f);
        Vector3 smoothPosition  = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}