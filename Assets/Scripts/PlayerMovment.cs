
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.6f;



    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space))
         {
            // rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "gold")
        {

            Destroy(other.gameObject);
        }
    }
}
