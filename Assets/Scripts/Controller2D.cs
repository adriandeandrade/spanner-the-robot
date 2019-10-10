using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31; // CharacterController2D Creator

public class Controller2D : MonoBehaviour
{
	// Inspector Fields
	[Header("Controller Settings")]
	[SerializeField] private float gravity = -25f;
	[SerializeField] private float runSpeed = 8f;
	[SerializeField] private float groundDamping = 20f;
	[SerializeField] private float inAirDamping = 5f;
	[SerializeField] private float jumpHeight = 3f;
	[SerializeField] private KeyCode jumpButton;

	// Private Variables
	private float normalizedHorizontalSpeed = 0f;

	// Components
	private CharacterController2D controller2D;
	private RaycastHit2D lastControllerColliderHit;
	private Vector2 velocity;
	private Vector2 movement;

	private void Awake()
	{
		controller2D = GetComponent<CharacterController2D>();

		controller2D.onControllerCollidedEvent += OnControllerCollider;
		controller2D.onTriggerEnterEvent += OnTriggerEnterEvent;
		controller2D.onTriggerExitEvent += OnTriggerExitEvent;
	}

	private void OnControllerCollider(RaycastHit2D hit)
	{
		if (hit.normal.y == 1f)
		{
			return;
		}
	}

	private void OnTriggerEnterEvent(Collider2D col)
	{

	}

	private void OnTriggerExitEvent(Collider2D col)
	{

	}

	private void Update()
	{
		if (controller2D.isGrounded) velocity.y = 0;

		movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

		if (movement.x == 1)
		{
			normalizedHorizontalSpeed = 1;

			if (transform.localScale.x < 0f)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
		else if (movement.x == -1)
		{
			normalizedHorizontalSpeed = -1;

			if (transform.localScale.x > 0f)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
		else
		{
			normalizedHorizontalSpeed = 0;
		}

		if (controller2D.isGrounded && Input.GetKeyDown(jumpButton))
		{
			velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
		}

		var smoothedMovementFactor = controller2D.isGrounded ? groundDamping : inAirDamping;
		velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);
		velocity.y += gravity * Time.deltaTime;

        controller2D.move(velocity * Time.deltaTime);
        velocity = controller2D.velocity;
	}
}
