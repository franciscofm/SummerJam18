using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

	public float gameDuration;
	private Controller _controller;

	private List<Transform> _deskPositions;
	private List<Worker> _workers;
	public Transform occupiedDesk; //Prefab
	public Transform freeDesk; //Prefab

	// Use this for initialization
	void Start () {
		_controller = FindObjectOfType<Controller> ();

		_workers = _controller.workers;
		for (int i = 0; i < _deskPositions.Count; i++) {
			GameObject desk;
			if (i < _workers.Count) {
				desk = SpawnOccupiedDesk (_deskPositions [i], _workers[i]);
			} else {
				desk = SpawnFreeDesk (_deskPositions[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < _workers.Count; i++) {
			_workers [i].UpdateStatus (deltaTime);
			if (_workers [i].WantsToLeave ()) {
				LoseWorker (_workers [i]);
				_workers [i].LeaveDesk ();
			}
		}
	}

	public GameObject SpawnOccupiedDesk (Transform deskPosition, Worker assignedWorker){
		Transform deskTransform;
		if (assignedWorker.HasDesk ()) {
			deskTransform = assignedWorker.GetDeskTransform ();
		} else {
			deskTransform = deskPosition;
		}
		GameObject desk = Instantiate (occupiedDesk.gameObject, deskTransform.position, deskTransform.localRotation);
		desk.transform.position = deskPosition.position;
		assignedWorker.AssignDesk (desk.transform);
		return desk;
	}

	public GameObject SpawnFreeDesk (Transform deskPosition){
		GameObject desk = Instantiate (freeDesk.gameObject);
		desk.transform.position = deskPosition.position;
		return desk;
	}

	public void LoseWorker(Worker lostWorker){
		_workers.Remove (lostWorker);
	}
}
