using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class MeleeEnemy : BaseEnemy
{
    // Inspector Fields
    [Header("Movement Settings")]
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float groundDamping = 15f;
    [SerializeField] private float maxDistanceBeforeTurningAround = 1f;

    // Private Variables
    [SerializeField] private float normalizedHorizontalSpeed = 1f;

    // Componenents
    private CharacterController2D controller2D;
    private Vector2 velocity;

    private void Awake()
    {
        controller2D = GetComponent<CharacterController2D>();
        controller2D.onControllerCollidedEvent += OnControllerCollider;
    }

    private void OnControllerCollider(RaycastHit2D hit)
    {
        if (hit.normal.y == 1f)
        {
            return;
        }

        if(hit.distance <= maxDistanceBeforeTurningAround)
        {
            if (normalizedHorizontalSpeed == 1)
                normalizedHorizontalSpeed = -1;
            else if (normalizedHorizontalSpeed == -1)
                normalizedHorizontalSpeed = 1;
        }
    }

    private void Update()
    {
        if (controller2D.isGrounded) velocity.y = 0;

        if (normalizedHorizontalSpeed == 1)
        {
            if (transform.localScale.x < 0f)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (normalizedHorizontalSpeed == -1)
        {
            if (transform.localScale.x > 0f)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * moveSpeed, Time.deltaTime * groundDamping);
        velocity.y += gravity * Time.deltaTime;

        controller2D.move(velocity * Time.deltaTime);
        velocity = controller2D.velocity;

    }
}
