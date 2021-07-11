using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{

	public bool isDead = false ;

	public double maxSainty = 100;
	public int maxHealth = 100;
	public int currentAmmo = 0;

	//Every other script can get the value but not change it
	public int currentHealth { get; private set; }
	public double currentSainty { get; private set; }

	public Stat damage;

	public int MaxDamageTaken = 50;


	private void Awake()
	{
		currentHealth = maxHealth;
		currentSainty = maxSainty;
	}

	void Update()
	{
		if (currentSainty > 0)
		{
			currentSainty -= Time.deltaTime * 0.2;
		}
		else
		{
			Die();
		}
	}

	public void takeDamage(int damageTaken)
	{

		//make sure that the damage is between 0 to infinity
		damageTaken = Mathf.Clamp(damageTaken, 0, MaxDamageTaken);

		currentHealth -= damageTaken;
		Debug.Log(transform.name + " takes " + damageTaken + " damage");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void pickUpAmmo()
	{

		currentAmmo += 7;
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

		Player_manager.instance.KillPlayer();
	}


}
