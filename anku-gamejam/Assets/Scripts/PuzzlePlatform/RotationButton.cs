using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationButton : MonoBehaviour
{
    public bool isPressing;
    public CinemachineVirtualCamera cam;
    public Transform target;
    public Transform player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPressing = true;
        StartCoroutine(gocam());
    }

    IEnumerator gocam()
    {
        cam.Follow = target.transform;
        yield return new WaitForSeconds(5f);
        cam.Follow = player.transform;
    }
}
