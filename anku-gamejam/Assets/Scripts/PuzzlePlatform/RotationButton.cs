using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationButton : MonoBehaviour
{
    public bool isPressing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPressing = true;
    }


}
