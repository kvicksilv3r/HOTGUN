using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	[SerializeField]
	protected Transform cameraHolster;

	protected Vector2 lookVector;

	[SerializeField]
	protected float clampHigh = 90, clampLow = -90;

	protected float deadzone = 0.25f;

	[SerializeField]
	protected Vector2 mouseSensitivity = Vector2.one;

	protected Vector2 rawInput = Vector2.zero;
	protected Vector2 modifiedInput = Vector2.zero;

	protected CharacterController characterController;

	protected float controllerRotationAccelerator = 1f;
	protected const float controllerRotationMaxAcceleration = 2f;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		ProcessMouseInput();

		RotateCharacter();
	}

	void ProcessMouseInput()
	{
		var mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		ValidateRotation(mouseInput * mouseSensitivity);
	}

	void ProcessJoystickInput()
	{
		rawInput.x = Input.GetAxisRaw("LookHorizontal");
		rawInput.y = Input.GetAxisRaw("LookVertical");

		print(rawInput.magnitude);

		if (rawInput.magnitude < deadzone)
		{
			rawInput = Vector2.zero;
			modifiedInput = Vector2.zero;
		}

		ValidateRotation(rawInput);
	}

	void ValidateRotation(Vector2 input)
	{
		lookVector.x = input.x;
		lookVector.y += input.y;

		lookVector.y = Mathf.Clamp(lookVector.y, clampLow, clampHigh);
	}

	void RotateCharacter()
	{
		cameraHolster.localRotation = Quaternion.identity *
			Quaternion.Euler(-lookVector.y, 0, 0);

		transform.Rotate(Vector3.up, lookVector.x);
	}
}