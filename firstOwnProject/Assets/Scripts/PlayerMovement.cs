using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //public
    public Joystick joystick;
    public float speed = 5f;
    public int health = 3;
    public Image[] healthImages;
    //private
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        h += Input.GetAxis("Horizontal");
        v += Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed;
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
        if (health > 0)
        {
            ShowHearts();
        }
        else
        { 
            GameManager.instance.SetGameOver(); 
        }
    }

    private void ShowHearts()
    {
        for(int i=0;i< healthImages.Length; i++)
        {
            healthImages[i].enabled=i<health;
        }
    }
}