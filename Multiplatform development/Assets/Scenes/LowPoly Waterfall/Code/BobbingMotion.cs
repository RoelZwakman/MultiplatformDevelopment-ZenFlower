using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingMotion : MonoBehaviour {

    Transform cachedTransform;
    Vector3 temppos;
    public float magnitude;
    public float speed;

    void Start()
    {
        cachedTransform = transform;
    }

    void Update()
    {
        BobbingMotionMovement(magnitude, speed);
    }

    void BobbingMotionMovement(float _mag, float _speed)
    {
        temppos = cachedTransform.position;
        temppos.y = Remap(Mathf.Sin(_speed * Time.time), -1, 1, -_mag, _mag );
        cachedTransform.position = temppos;
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
