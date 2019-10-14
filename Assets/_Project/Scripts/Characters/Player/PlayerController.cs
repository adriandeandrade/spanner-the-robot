using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31; // CharacterController2D Creator

public class PlayerController : MonoBehaviour
{
	// Inspector Fields
	[Header("Controller Settings")]
	[SerializeField] private float gravity = -30f;
	[SerializeField] private float runSpeed = 2f;
	[SerializeField] private float groundDamping = 15f;
	[SerializeField] private float inAirDamping = 5f;
	[SerializeField] private float jumpHeight = 4f;
	[SerializeField] private KeyCode jumpButton = KeyCode.Space;

	// Private Variables
	private float normalizedHorizontalSpeed = 0f;

	// Components
	private Animator animator;
	private CharacterController2D controller2D;
	private RaycastHit2D lastControllerColliderHit;
	private Vector2 velocity;
	private Vector2 horizontalInput;

	private void Awake()
	{
		controller2D = GetComponent<CharacterController2D>();
		animator = GetComponent<Animator>();

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
		if (col.gameObject.CompareTag("Item"))
		{
			InteractableItem item = col.gameObject.GetComponent<InteractableItem>();

			if (item != null)
			{
				item.HandleItem();
			}
		}
		else if (col.gameObject.CompareTag("Laser"))
		{
			Toolbox.instance.GetGameManager().RespawnPlayer();
		}
		else if(col.gameObject.CompareTag("Platform"))
		{
			transform.parent = col.transform;
		}

	}

	private void OnTriggerExitEvent(Collider2D col)
	{
		if(col.gameObject.CompareTag("Platform"))
		{
			transform.parent = null;
		}
	}

	private void Update()
	{
		if (controller2D.isGrounded) velocity.y = 0;

		horizontalInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

		if (horizontalInput.x == 1)
		{
			normalizedHorizontalSpeed = 1;
			animator.SetBool("isMoving", true);

			if (transform.localScale.x < 0f)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
		else if (horizontalInput.x == -1)
		{
			normalizedHorizontalSpeed = -1;
			animator.SetBool("isMoving", true);

			if (transform.localScale.x > 0f)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
		else
		{
			normalizedHorizontalSpeed = 0;
			animator.SetBool("isMoving", false);
		}

		if (controller2D.isGrounded && Input.GetKeyDown(jumpButton))
		{
			velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
		}

		float smoothedMovementFactor = controller2D.isGrounded ? groundDamping : inAirDamping;

		velocity.x = Mathf.Lerp(velocity.x, horizontalInput.x * runSpeed, Time.deltaTime * smoothedMovementFactor);
		velocity.y += gravity * Time.deltaTime;

		controller2D.move(velocity * Time.deltaTime);
		velocity = controller2D.velocity;
	}
}
