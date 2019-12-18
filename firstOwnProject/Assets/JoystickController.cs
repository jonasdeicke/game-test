using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }
}
