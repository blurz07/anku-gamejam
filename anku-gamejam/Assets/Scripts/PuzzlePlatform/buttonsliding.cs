using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;
public class buttonsliding : MonoBehaviour
{
    public Transform target;
    public Ease ease;
    public float platformSpeed;
    public BridgeButton button;
    public Transform backtarget;

    private void Update()
    {
        if (button.isPress)
        {
            transform.DOMove(target.position, platformSpeed);
        }
        else
        {
            transform.DOMove(backtarget.position, platformSpeed);
        }


    }

    
        
    
}
