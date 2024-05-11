using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce = 250f;
    public GameObject BulletPrefab;
    private bool firing;
    void Start()
    {
        
    }

    void Update()
    {
        if (firing == false)
        {
            StartCoroutine(Fire());

        }

    }
    IEnumerator Fire()
    {
        firing = true;
        GameObject Bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3f);
        firing = false;
    }
}
