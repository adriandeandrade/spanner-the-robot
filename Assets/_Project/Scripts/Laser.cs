using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	// Inspector Fields
	[Header("Laser Settings")]
	[SerializeField] private float startOffset;
	[SerializeField] private float activeTime;
	[SerializeField] private float offTime;
	[SerializeField] private GameObject laserGFX;

	// Private Variables
	private BoxCollider2D boxCollider;

	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider2D>();

		Invoke("StartLaser", startOffset);
	}

	private void StartLaser()
	{
		StartCoroutine(LaserRoutine());
	}

	private IEnumerator LaserRoutine()
	{
		while (true)
		{
			EnableLaser();
			yield return new WaitForSeconds(activeTime);
			DisableLaser();
			yield return new WaitForSeconds(offTime);
		}
	}

	private void EnableLaser()
	{
		laserGFX.SetActive(true);
		boxCollider.enabled = true;
	}

	private void DisableLaser()
	{
		laserGFX.SetActive(false);
		boxCollider.enabled = false;
	}
}
