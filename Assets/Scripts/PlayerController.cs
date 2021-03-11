﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && velocity.y < 0)
		{
            velocity.y = 0f;
		}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed *Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            isGrounded = false;

        }
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Ground")
		{
            isGrounded = true;
		}
	}
}
