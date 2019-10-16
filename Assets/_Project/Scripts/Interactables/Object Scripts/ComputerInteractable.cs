using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteractable : ObjectInteractable
{
	// Inspector Fields
	[Header("Computer Settings")]
	[SerializeField] private GameObject objectToActivate;

	private void Awake()
	{
		interactionUI = GetComponentInChildren<InteractionUI>();
	}

	public override void Interact()
	{
		isInteractable = false;
		objectToActivate.GetComponent<IActivateable>().Activate();
	}
}
