using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
	[Header("Ship Flight Adjustments")]

	[Tooltip("In meters per sec.")]	[SerializeField]	float xSpeed = 10f;
	[Tooltip("In meters per sec.")] [SerializeField] float ySpeed = 10f;
	
	[Header("Rotation Factors")]
	[SerializeField] float positionPitchFactor = -6f;
	[SerializeField] float controlPitchFactor = -7.5f;
	[SerializeField] float positionYawFactor = 5f;
	[SerializeField] float controlRollFactor = -7.5f;

	[Header("Screen Ranges")]
	public float xRange = 5f;
	public float yRange = 3.5f;
	public float xThrow, yThrow;

	bool canMove = true;

	void OnPlayerDeath() //Called by string reference
	{
		canMove = false;
		print("Movment Stopped");
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove)
		{
			ProcessTranslation();
			ProcessRotation();
		}
		
	}

	private void ProcessRotation()
	{
		float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
		float yaw = transform.localPosition.x * positionYawFactor;
		float roll = xThrow * controlRollFactor;
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float yOffset = yThrow * ySpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;
		float clampedXPox = Mathf.Clamp(rawXPos, -xRange, xRange);

		float rawYPos = transform.localPosition.y + yOffset;
		float clampedYPox = Mathf.Clamp(rawYPos, -yRange, yRange);

		transform.localPosition = new Vector3(clampedXPox, clampedYPox, transform.localPosition.z);
	}
}
