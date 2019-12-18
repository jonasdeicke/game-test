using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -10);
    //public float smoothTime = 0.3f;

    private Transform playerTransform;
    //private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        //// Smoothly move the camera towards that target position
        //Vector3 targetPosition = playerTransform.TransformPoint(new Vector3(0, 0, -10));
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); 
    }

}
