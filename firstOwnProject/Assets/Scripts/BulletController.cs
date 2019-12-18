using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.time - startTime;
        if (deltaTime < 1)
        {
            rb.velocity *= 1 - deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
