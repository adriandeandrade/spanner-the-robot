using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Inspector Variable
    [Header ("Input Manager Settings")]
    public string verticalAxis = "Vertical";
    public string horizontalAxis = "Horizontal";
    public KeyCode jumpButton = KeyCode.Space;

    // Private Variables
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;
    [HideInInspector] public Vector2 movement;

    // Components

    private void Update ()
    {
        horizontalInput = Input.GetAxisRaw(horizontalAxis);
        verticalInput = Input.GetAxisRaw(verticalAxis);

        movement = new Vector2(horizontalInput, verticalInput);
        movement.y = 0;
    }
}