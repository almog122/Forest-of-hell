using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 2f;

    [SerializeField]
    private GameObject player;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();

    }

    
    private void ChasePlayer()
    {
        transform.LookAt(player.transform);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }


}
