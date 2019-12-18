using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletOffset=0.7f;
    public float bulletSpeed = 20f;
    public float minTimeBetweenShots = 0.3f;
    Rigidbody2D rigidbody;
    float lastShotTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
        if(Time.time-lastShotTime>minTimeBetweenShots)
        {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.right;
        Quaternion playerRotation = transform.rotation;

        Vector3 spawnPos = playerPos + playerDirection * bulletOffset;

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, playerRotation);
        bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * bulletSpeed;

        AudioManager.instance.PlayPlayerShot();

            lastShotTime = Time.time;
        }
    }
    
}
