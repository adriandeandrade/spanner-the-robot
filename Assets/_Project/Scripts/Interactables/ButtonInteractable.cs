using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonInteractable : Interactable
{
	// Inspector Fields
	[Header("Button Interactable Settings")]
	[SerializeField] private Interactable objectToActivate;
	[SerializeField] private InteractionUI interactionUI;

	// Private Variables
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		interactionUI = GetComponentInChildren<InteractionUI>();
	}

	public override void Interact()
	{
		animator.SetTrigger("PressButton");
		isInteractable = false;
	}
	public override void EnableUI()
	{
		if (isInteractable)
		{
			interactionUI.EnableInteractionUI();
		}
	}

	public override void DisableUI()
	{
		interactionUI.DisableInteractionUI();
	}

	// Called by animation event
	public void OnButtonPressAnimationDone()
	{
		if (objectToActivate != null)
		{
			objectToActivate.Interact();
		}
	}
}
