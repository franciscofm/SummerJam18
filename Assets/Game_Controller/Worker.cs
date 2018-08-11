using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker {

	public int level;
	public int days;

	public string name;
	public string surname;

	public float laziness; //indice a escaquearse
	public float efficiency; //multiplicador para lo que se

	private float _happiness; //status in game (0 == lost)
	private bool _isLeaving;
	private bool _left;
	private float _walkSpeed;

	private Transform _modelTransform;
	private Transform _desk;
	
	public Worker() {
		name = Values.Names [Random.Range (0, Values.Names.Length)];
		surname = Values.Surnames [Random.Range (0, Values.Surnames.Length)];

		level = 0;
		days = 0;

		laziness = Random.Range (0f, 0.4f);
		efficiency = Random.Range (0.5f, 0.7f);

		_happiness = Random.Range (0.8f, 1f);
	}

	public void Work() {
		++days;
		if (days > 15) {
			days = 0;
			LevelUp ();
		}
	}

	public void LevelUp() {
		if (level > 4) return;
		++level;
		laziness = Mathf.Clamp01 (laziness - 0.07f);
		efficiency = Mathf.Clamp01 (efficiency + 0.1f);
		_happiness = Mathf.Clamp01 (_happiness + 0.1f);
	}

	public Manager Promote() {
		Manager manager = new Manager ();
		manager.name = name;
		manager.surname = surname;
		manager.efficiency = efficiency;

		return manager;
	}

	public void AssignDesk(Transform desk){
		_desk = desk;
	}

	public bool HasDesk(){
		return _desk != null;
	}

	public Transform GetDeskTransform(){
		return _desk;
	}

	public void UpdateStatus (float deltaTime) {
		if (_isLeaving) {
			if (Mathf.Approximately(_modelTransform.position.z, 0f)) {
				if (Mathf.Approximately (_modelTransform.position.x, 20f)) {
					_left = true;
					_modelTransform.gameObject.SetActive (false);
					return;
				}
				_modelTransform.Translate (_walkSpeed * deltaTime, 0f, 0f); // Only walking towards positive X
				return;
			}
			float dir = _modelTransform.position.z > 0 ? -1 : 1; // Determine Z walking direction
			_modelTransform.Translate(0f, 0f, dir * _walkSpeed * deltaTime);
			return;
		}
		_happiness = Mathf.Clamp01 (_happiness - laziness * Random.value * 0.1f);
	}

	public bool WantsToLeave(){
		return _happiness < 0.1f;
	}

	public void LeaveDesk(){
		_isLeaving = true;
	}
}
