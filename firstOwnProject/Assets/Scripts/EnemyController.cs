using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosition;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.Find("PlayerImage");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
        Vector3 direction = playerPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletController b = collision.GetComponent<BulletController>();
        if (b)
        {
            Destroy(gameObject);
            AudioManager.instance.PlayHitSound();
            GameManager.instance.IncreaseScore();
            return;
        }
        PlayerMovement p = collision.GetComponent<PlayerMovement>();
        if (p)
        {
            //Destroy(player);
            AudioManager.instance.PlayHitSound();
            GameManager.instance.SetGameOver();
            return;
        }

    }
}
