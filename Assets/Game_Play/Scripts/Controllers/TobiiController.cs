using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobiiController : MonoBehaviour {

	public PlayerContoller _playerController;

	[SerializeField]
	private Vector2 _gazePos;
	
	// Update is called once per frame
	void Update () {
		// Get Tobii position
		_gazePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		float distance = _gazePos.x;
		// Check whether player is looking at left (< 0.5) or right (> 0.5) side of the screen
		float side = distance / Screen.width;
		// Transform values to -1.0 .. 1.0
		float direction = Mathf.Clamp ((side - 0.5f) * 2f, -1f, 1f);
		_playerController.UpdateGazeDirection (direction);
	}
}
