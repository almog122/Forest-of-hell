using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy_Stats : MonoBehaviour
{

	Enemy_Stats myStats;

	public float attackSpeed = 1f;

	public float attackCooldown = 0f;

	public float attackDelay = 0.6f;

	public bool isAttacking = false;

	//Call back function
	public event System.Action OnAttack;

	void Start()
	{
		myStats = GetComponent<Enemy_Stats>();
	}

	void Update()
	{
		attackCooldown -= Time.deltaTime;

		//stop attack animation when not attacking
		if (attackCooldown < 0)
		{
			isAttacking = false;
		}

	}

	public void Attack(PlayerStats targetStats)
	{
		if (attackCooldown < 0)
		{
			isAttacking = true;

			StartCoroutine(DoDamage(targetStats, attackDelay));

			attackCooldown = 2f / attackSpeed;

			if(OnAttack != null)
			{
				OnAttack();
			}
		}
	}



	IEnumerator DoDamage(PlayerStats player, float delay)
	{
		yield return new WaitForSeconds(delay);

	//	player.takeDamage(myStats.damage);
	}



}
