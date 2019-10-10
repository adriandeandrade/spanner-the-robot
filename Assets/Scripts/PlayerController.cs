using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Inspector Fields
	[Header("Player Controller Settings")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveSpeedSmoothing = 0.5f;
	[SerializeField] private float jumpAmount;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private KeyCode jumpButton;

	// Private Variables
	private Vector2 movementVector;
	private bool isGrounded = true;
	private bool isJumping = false;
	private float rayLength;
    private float moveSpeedOld;
	private const float skinWidth = 0.015f;

	// Components
	private Rigidbody2D rBody;
	private BoxCollider2D col;
	private Vector2 Velocity;

	private void Awake()
	{
		rBody = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
	}

	private void Start()
	{
		rayLength = col.bounds.extents.y;
	}

	private void Update()
	{
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f);
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(jumpButton) && isGrounded)
		{
			StartCoroutine(Jump());
		}

		Vector2 targetVelocity = new Vector2(movementVector.x * 10f, rBody.velocity.y);
		rBody.velocity = Vector2.SmoothDamp(rBody.velocity, targetVelocity, ref Velocity, moveSpeedSmoothing);
	}

	private IEnumerator Jump()
	{
        rBody.AddForce(new Vector2(0f, jumpAmount), ForceMode2D.Impulse);

		isJumping = true;
		isGrounded = false;

        moveSpeedOld = moveSpeed;
		moveSpeed /= 2;
        

		yield return null;

		while (!isGrounded)
		{
			RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, rayLength + 0.1f, groundLayer);

			if (hitGround)
			{
				isGrounded = true;
			}

			yield return null;
		}

		isGrounded = true;
		isJumping = false;
		moveSpeed = moveSpeedOld;
		yield break;
	}
}
