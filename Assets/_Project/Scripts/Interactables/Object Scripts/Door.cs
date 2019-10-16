using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, IActivateable
{
	// Inspector Fields
	[SerializeField] private bool isFinalDoor;

	// Private Variables
	private Animator animator;
    private BoxCollider2D boxCollider;

	private void Awake()
	{
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
	}

	public void Activate()
	{
		animator.SetTrigger("OpenDoor");

		if(isFinalDoor)
		{
			Toolbox.instance.GetGameManager().LevelOver();
		}
	}
}
