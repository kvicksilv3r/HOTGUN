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

    private Vector3 horizontalVelocity;

    public float movementDampening = 1;
    public float maxMovementSpeed = 5;

    public float airMultiplier = 0.25f;
    private float currentAirMultiplier = 1;

    private void Start()
    {
        Shotgun.Instance.e_shoot.AddListener(AddKnockback);
    }

    void Update()
    {
        FetchInput();
        CheckJump();
        HandleVelocity();
        HandleGravity();
        TranslatePlayer();
    }

    private void HandleGravity()
    {
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
        _movement = horizontalVelocity + Vector3.up * _verticalVelocity;
        _characterController.Move(_movement * Time.deltaTime);
    }

    private void HandleVelocity()
    {
        currentAirMultiplier = _characterController.isGrounded ? 1 : airMultiplier;
        horizontalVelocity += _input * Time.deltaTime * _movementSpeed * currentAirMultiplier;
        horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, maxMovementSpeed);
        horizontalVelocity = Vector3.MoveTowards(horizontalVelocity, Vector3.zero, movementDampening * Time.deltaTime * currentAirMultiplier);
    }

    private void FetchInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.z = Input.GetAxisRaw("Vertical");

        _input = transform.TransformVector(_input) * _movementSpeed;
    }

    private void AddKnockback()
    {
        var camBack = _camera.forward * -1;
        var knockback = camBack * Player.Instance.shotgun.knockbackPower;

        _verticalVelocity += knockback.y;

        horizontalVelocity += new Vector3(knockback.x, 0, knockback.z);
    }
}
