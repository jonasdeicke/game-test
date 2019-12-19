using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Joystick joystick;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float minTimeBetweenShots = 0.3f;
    public Vector3 offsetVector = new Vector3(0.3f, -0.9f, 0f);

    Rigidbody2D rb;
    float lastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();

        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        if (h!=0f || v!=0f)
            Shoot();
    }

    public void RotatePlayer()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        Vector2 dir = new Vector2(h, v);

        if (dir != Vector2.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    
    public void Shoot()
    {
        if (Time.time - lastShotTime > minTimeBetweenShots)
        {
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.right;
            Quaternion playerRotation = transform.rotation;

            //bullet offset
            Vector3 v3=transform.InverseTransformPoint(playerPos);
            v3+= offsetVector;
            playerPos = transform.TransformPoint(v3);

            Vector3 spawnPos = playerPos + playerDirection;

            GameObject bullet = Instantiate(bulletPrefab, spawnPos, playerRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * bulletSpeed;

            AudioManager.instance.PlayPlayerShot();

            lastShotTime = Time.time;
        }
    }
}
