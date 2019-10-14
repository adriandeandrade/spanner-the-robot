using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteractable : Interactable
{
	// Inspector Fields
	[Header("Computer Settings")]
	[SerializeField] private GameObject objectToActivate;
	[SerializeField] private InteractionUI interactionUI;

	private void Awake()
	{
		interactionUI = GetComponentInChildren<InteractionUI>();
	}

	public override void Interact()
	{
		isInteractable = false;
		objectToActivate.GetComponent<IActivateable>().Activate();
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
}
