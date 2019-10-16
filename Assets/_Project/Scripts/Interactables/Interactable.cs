using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Inspector Fields
    [Header("Interactable Settings")]
    [SerializeField] protected bool isInteractable = true;

	public abstract void Interact();
}
