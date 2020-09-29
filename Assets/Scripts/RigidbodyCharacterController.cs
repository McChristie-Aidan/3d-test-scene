﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;
    [SerializeField]
    private float maxSpeed = 2;
    [SerializeField]
    private PhysicMaterial stoppingMat, movingMat;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new CapsuleCollider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        var inputDir = new Vector3(input.x, 0, input.y);

        if (inputDir.magnitude > 0)
        {
            collider.material = movingMat;
        }
        else
        {
            collider.material = stoppingMat;
        }

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(inputDir * accelerationForce, ForceMode.Acceleration);
        }
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}