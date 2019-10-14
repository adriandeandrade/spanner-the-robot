using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorInteractable : Interactable
{
	// Inspector Fields

	// Private Variables
	private Animator animator;
    private BoxCollider2D boxCollider;

	private void Awake()
	{
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
	}

	public override void Interact()
	{
		animator.SetTrigger("OpenDoor");
	}

    public void OnAnimationFinished()
    {
        
    }
}
