using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBridge : MonoBehaviour
{
    public RotationButton button;
    public Transform from;
    public Transform to;
    public float speed = 0.01f;
    float timeCount = 0f;

    void Update()
    {
        if(button.isPressing)
        {
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;
        }
    }
}
