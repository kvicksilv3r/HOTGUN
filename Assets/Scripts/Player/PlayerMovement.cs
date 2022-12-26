using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _input;

    [SerializeField]
    private float _movementSpeed = 5;

    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private Transform _camera;

    [SerializeField]
    private float _jumpForce = 5;

    [SerializeField]
    private float _gravitationalStength = 6;

    private float _verticalVelocity = 0;

    private Vector3 _movement;

    // Update is called once per frame
    void Update()
    {
        FetchInput();
        CheckJump();
        HandleGravity();
        TranslatePlayer();
    }

    private void HandleGravity()
    {
        //if (!_characterController.isGrounded)
        _verticalVelocity -= Time.deltaTime * _gravitationalStength;
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded && !Shotgun.Instance.IsReloading)
        {
            _verticalVelocity = _jumpForce;
        }
    }

    private void TranslatePlayer()
    {
        _movement = _input + Vector3.up * _verticalVelocity;
        _characterController.Move(_movement * Time.deltaTime);
        //_characterController.SimpleMove(_input * _movementSpeed * Time.deltaTime);
    }

    private void FetchInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.z = Input.GetAxisRaw("Vertical");

        _input = transform.TransformVector(_input) * _movementSpeed;
    }
}
