using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    // Inspector Fields
    [Header("Interactable Item Data")]
    [SerializeField] protected Item item;

	public override void Interact()
	{
		
	}

    public virtual void HandleItem()
    {
        Destroy(gameObject);
    }
}
