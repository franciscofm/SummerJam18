using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Transform selfCamera;

	// Update to match the player model direction
	void Start () {
		selfCamera.LookAt (target.position);
	}
}
