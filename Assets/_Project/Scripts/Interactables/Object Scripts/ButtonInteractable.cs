using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonInteractable : ObjectInteractable
{
	// Inspector Fields
	[Header("Button Interactable Settings")]
	[SerializeField] private GameObject objectToActivate;

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
	

	// Called by animation event
	public void OnButtonPressAnimationDone()
	{
		if (objectToActivate != null)
		{
			objectToActivate.GetComponent<IActivateable>().Activate();
		}
	}
}
