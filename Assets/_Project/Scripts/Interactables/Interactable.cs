using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Inspector Fields
    [Header("Interactable Settings")]
    [SerializeField] protected bool isInteractable = true;

    // Private Variables

	public abstract void Interact();

    public virtual void EnableUI()
    {

    }

    public virtual void DisableUI()
    {

    }
}
