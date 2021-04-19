using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SpectatorInput : MonoBehaviour
{
    private CharacterController _controller;

    public float speed = 20.0f;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = 0.0f;
        if (Input.GetKey(KeyCode.Q))
            deltaY = -speed;
        else if (Input.GetKey(KeyCode.E))
            deltaY = speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, deltaY, 0.0f);
        movement = transform.TransformDirection(movement);
        movement += transform.forward * deltaZ;
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        _controller.Move(movement);
    }
}
