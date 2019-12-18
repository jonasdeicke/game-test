using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public
    public Joystick joystick;
    public float speed = 10f;

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

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed;
    }
}