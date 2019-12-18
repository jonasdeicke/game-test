using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 1f;
    Rigidbody2D rigidbody;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h += joystick.Horizontal;
        v += joystick.Vertical;

        Vector2 dir = new Vector2(h, v);
        rigidbody.velocity = dir * speed;

        RotationToMovementDirection();
    }

    private void RotationToMovementDirection()
    {
            Vector2 moveDirection = rigidbody.velocity;
            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

    }
}