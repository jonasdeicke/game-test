using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startTime = Time.time;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //float deltaTime = Time.time - startTime;
        //if (deltaTime < 1)
        //{
        //    rb.velocity *= 1 - deltaTime;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        if(!IsOnScreen(rb.position))
        {
            Destroy(gameObject);
        }

    }

    public bool IsOnScreen(Vector3 position)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return onScreen;
    }
}
