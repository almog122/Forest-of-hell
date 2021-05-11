using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject player;

    Enemy_combat combat;

    Enemy_controller controller;

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<Enemy_combat>();

        controller = GetComponent<Enemy_controller>();
    }

    // Update is called once per frame
    void Update()
    {

		if (controller.attackRange)
		{
            combat.Attack();

		}
        


    }
}
