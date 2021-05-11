using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_objects : MonoBehaviour
{
    //The radius of the colliders around the objects
    public float radiusCollider = 3f;

	public Transform interactionTransform;

	//check if the current object is the player focus
	bool isFocus = false;

	Transform player;

	[SerializeField]
	private bool isEnemy = false;

	public bool isAttackFire = false;

	//check if the current object was already interacted with (so that it won't interact multipal times)
	bool isInteracted = false;

	private void Update()
	{
		if (isFocus && !isInteracted)
		{
			//the distance between the player and the current object
			float distance = Vector3.Distance(player.position, transform.position);

			if (!isEnemy)
			{
				//we check that the player is inside our collider
				if (distance <= radiusCollider)
				{
					interact();

					isInteracted = true;
				}
			}

			else
			{
				if (!(isAttackFire))
				{
					//we check that the player is inside our collider
					if (distance <= radiusCollider)
					{
						interact();

						isInteracted = true;
					}
				}
				else
				{
					//we check that the player is inside our collider
					if (distance <= radiusCollider * 3f)
					{
						interact();

						isInteracted = true;
					}
				}
			}
		}
	}

	//So every child class will take this method and implement it as they need to
	public virtual void interact()
	{

	}

	//Drawing the collider in the scene
	private void OnDrawGizmosSelected()
	{

		if(interactionTransform == null)
		{
			interactionTransform = transform;
		}


		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position , radiusCollider);

	}

	//when the player start focusing on the current object
	public void onFocused(Transform playerTransform , bool attackType)
	{
		isFocus = true;

		player = playerTransform;

		isAttackFire = attackType;

		isInteracted = false;
	}

	//when the player stop focusing on the current object
	public void deFocused()
	{
		isFocus = false;

		player = null;

		isInteracted = false;
	}


}
