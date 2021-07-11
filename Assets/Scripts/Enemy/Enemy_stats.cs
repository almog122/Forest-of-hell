using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stats : MonoBehaviour
{
	public bool isDead = false;

	public int maxHealth = 100;

	//Every other script can get the value but not change it
	public int currentHealth { get; private set; }

	public Stat damage;

	public int MaxDamageTaken = 50;


	private void Awake()
	{
		currentHealth = maxHealth;
	}

	public void takeDamage(int damageTaken)
	{

		//make sure that the damage is between 0 to MaxDamageTaken
		//damageTaken = Mathf.Clamp(damageTaken, 0, MaxDamageTaken);

		currentHealth -= damageTaken;
		Debug.Log(transform.name + " takes " + damageTaken + " damage");

		if (currentHealth <= 0)
		{
			Die();
		}
	}
	void Die()
	{

		isDead = true;

		StartCoroutine(WaitForDeath(2f));
	}

	IEnumerator WaitForDeath(float delay)
	{
		yield return new WaitForSeconds(delay);

		isDead = false;

		Destroy(gameObject);
		
	}
}
