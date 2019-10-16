using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryItemInteractable : InteractableItem
{
    // Inspector Fields
    [SerializeField] private float amountOfEnergyToReplenish = 5;

	private Player player;

	private void Awake()
	{
        player = FindObjectOfType<Player>();
	}

	public override void HandleItem()
	{
        player.AddEnergy(amountOfEnergyToReplenish);
        base.HandleItem();
	}
}
