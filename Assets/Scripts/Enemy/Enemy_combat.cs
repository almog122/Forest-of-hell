using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy_combat : MonoBehaviour
{
	Player_manager playerManager;
	
	Enemy_stats myStats;

	public float attackSpeed = 1f;

	public float attackCooldown = 0f;

	public float attackDelay = 0.6f;

	public bool isAttacking = false;

	//Call back function
	public event System.Action OnAttack;

	void Start()
	{
		playerManager = Player_manager.instance;

		myStats = GetComponent<Enemy_stats>();

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

	public void Attack()
	{
		if (attackCooldown < 0)
		{
			isAttacking = true;

			StartCoroutine(DoDamage(attackDelay));

			attackCooldown = 2f / attackSpeed;

			if(OnAttack != null)
			{
				OnAttack();
			}
		}
	}



	IEnumerator DoDamage(float delay)
	{
		yield return new WaitForSeconds(delay);

		playerManager.Player.GetComponent<Player_Stats>().takeDamage(myStats.damage.getValue());
	}



}
