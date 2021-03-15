
using UnityEngine;
using UnityEngine.AI;

public class Enemy_controller : MonoBehaviour
{
    public GameObject player;

    Transform target;

    NavMeshAgent agent;

    //The area the enemy will start to attack
    public float lookRadius = 10f;


    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
		{
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
			{
                FaceTarget();

            }
		}
    }

    void FaceTarget()
	{
        Vector3 diraction = (target.position - transform.position).normalized;

        diraction = new Vector3(diraction.x, 0, diraction.z);

        Quaternion lookRatation = Quaternion.LookRotation(diraction);

        transform.rotation =Quaternion.Slerp(transform.rotation, lookRatation , Time.deltaTime * 5f);
	}

    //Drawing the collider in the scene
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
