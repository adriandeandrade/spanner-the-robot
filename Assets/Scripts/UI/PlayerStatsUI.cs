using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
	[Header("Stats UI Fields")]
	[SerializeField] private Image healthbar;
	[SerializeField] private Image energyBar;

	public void UpdateHealthBar(float maxValue, float currentValue)
	{
		if (healthbar != null)
		{
			healthbar.fillAmount = currentValue / maxValue;
		}
		else
		{
			Debug.Log("Health Bar not found, assign one in the inspector.");
		}

	}

	public void UpdateChargeBar(float maxValue, float currentValue)
	{
		if (energyBar != null)
		{
			energyBar.fillAmount = currentValue / maxValue;
		}
		else
		{
			Debug.Log("Energy Bar not found, assign one in the inspector.");
		}
	}
}
