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
	[SerializeField] private float noEnergyMoveSpeed;

	// Private Variables
	private float currentEnergy;
	private bool noEnergy = false;

	// Components
	private PlayerStatsUI playerStatsUI;
	private PlayerController playerController;

	public override void Awake()
	{
		base.Awake();

		playerController = GetComponent<PlayerController>();

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
				playerController.SetMoveSpeed(noEnergyMoveSpeed);
			}
		}
	}
	public override void TakeDamage(float damageAmount)
	{
		RecalculateHealth(damageAmount);

		if (currentHealth <= 0)
		{
			Toolbox.instance.GetGameManager().RespawnPlayer();
		}

		playerStatsUI.UpdateHealthBar(maxHealth, currentHealth);
	}

	public void AddEnergy(float amountToAdd)
	{
		if (noEnergy)
		{
			noEnergy = false;
			playerController.ResetSpeed();
		}

		currentEnergy += amountToAdd;
		currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
		playerStatsUI.UpdateChargeBar(maxEnergy, currentEnergy);
	}
}
