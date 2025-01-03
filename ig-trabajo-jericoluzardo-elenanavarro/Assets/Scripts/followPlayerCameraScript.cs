using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerCameraScript : MonoBehaviour
{

    private Vector3 _offset;
    public Transform target;
    public float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
