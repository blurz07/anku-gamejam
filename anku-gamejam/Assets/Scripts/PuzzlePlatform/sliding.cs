using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;
public class sliding : MonoBehaviour
{
    public Transform target;
    public Ease ease;
    public float platformSpeed;

    private void Start()
    {
        transform.DOMove(target.position, platformSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
