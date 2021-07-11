using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerEnemyAnimation : MonoBehaviour
{
    const float animationSmooth = 0.1f;

    NavMeshAgent agent;

    Animator animator;

    Enemy_combat combat;

    Enemy_stats dead;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();

        combat = GetComponent<Enemy_combat>();

        dead = GetComponent<Enemy_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        animationStart();

    }

    void animationStart()
    {
        float SpeedAnimation = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedAnimation", SpeedAnimation, animationSmooth, Time.deltaTime);

        //When you attack
        animator.SetBool("Attack", combat.isAttacking);

        //when you die
        animator.SetBool("Dead", dead.isDead);
    }
}
