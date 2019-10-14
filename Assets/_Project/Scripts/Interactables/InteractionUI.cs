using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InteractionUI : MonoBehaviour
{
	// Inspector Fields
	[Header("Interaction UI Settings")]

	// Private Variables
	private Animator animator;
	private bool isOpen;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void EnableInteractionUI()
	{
		if (!isOpen)
		{
			isOpen = true;
			animator.SetBool("IsOpen", true);
		}
	}

	public void DisableInteractionUI()
	{
		if (isOpen)
		{
			isOpen = false;
			animator.SetBool("IsOpen", false);
		}
	}
}
