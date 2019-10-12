using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatsUI))]
public class Player : BaseEntity
{
	// Inspector Fields
	[Header("Player Fields")]
	[SerializeField] private float maxEnergy;
	[SerializeField] private float energyDecreaseAmount;
	[SerializeField] private float healthDecreaseAmount; // How much health to remove.
	[SerializeField] private float healthDecreaseDelay; // For when theres no energy left.

	// Private Variables
	private float currentEnergy;
	private bool noEnergy = false;

	// Components
	private PlayerStatsUI playerStatsUI;

	public override void Awake()
	{
		base.Awake();

		if (playerStatsUI == null)
		{
			playerStatsUI = GetComponent<PlayerStatsUI>();
		}
	}

	private void Start()
	{
		currentEnergy = maxEnergy;
	}

	private void Update()
	{
		if (currentEnergy > 0)
		{
			currentEnergy -= energyDecreaseAmount * Time.deltaTime;
			playerStatsUI.UpdateChargeBar(maxEnergy, currentEnergy);
		}
		else
		{
			if (!noEnergy)
			{
				noEnergy = true;
				StartCoroutine(NoEnergyRoutine());
			}
		}
	}

	private IEnumerator NoEnergyRoutine()
	{
		while (noEnergy)
		{
			TakeDamage(healthDecreaseAmount);
			playerStatsUI.UpdateHealthBar(maxHealth, currentHealth);
			yield return new WaitForSeconds(healthDecreaseDelay);
		}

		yield break;
	}
}
