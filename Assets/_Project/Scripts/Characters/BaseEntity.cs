using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour, IDamageable
{
	// Inspector Fields
	[Header("Entity Fields")]
	[SerializeField] protected float maxHealth;

	// Private Variables
	protected float currentHealth;

	// Components

	public virtual void Awake()
	{
        currentHealth = maxHealth;
	}

	public virtual void TakeDamage(float damageAmount)
	{
		RecalculateHealth(damageAmount);

        if(currentHealth <= 0)
        {
            // TODO: Handle entity dieing.
        }

	}

    public virtual void RecalculateHealth(float amount)
    {
        currentHealth -= amount;
    }
}
