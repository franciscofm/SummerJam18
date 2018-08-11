using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

	[SerializeField]
	public Transform player;

	/*
	[SerializeField]
	private int _concentrationLevel;
	*/

	[SerializeField]
	private float _gazeRotationSpeed = 0;
	[SerializeField]
	private float _gazeDirection;
	[SerializeField]
	private float _horizontalSpeed = 0;
	[SerializeField]
	private float _verticalSpeed = 0;

	// Use this for initialization
	void Start () {
		//_concentrationLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;
		Move (deltaTime);
		UpdateLookDirection (deltaTime);
	}

	// Control WASD movement
	private void Move(float deltaTime) {
		float sideMovement = Input.GetAxisRaw ("Horizontal") * deltaTime * _horizontalSpeed;
		float frontMovement = Input.GetAxisRaw ("Vertical") * deltaTime * _verticalSpeed;
		player.Translate (sideMovement, 0, frontMovement);
	}

	public void UpdateGazeDirection(float gazeDirection){
		_gazeDirection = gazeDirection;
	}

	// Control view movement
	private void UpdateLookDirection(float deltaTime) {
		float gazeRotation = _gazeDirection * _gazeRotationSpeed * deltaTime;
		player.Rotate (0, gazeRotation, 0);
	}
}
