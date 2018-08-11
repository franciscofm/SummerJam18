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
	
	public Worker() {
		name = Values.Names [Random.Range (0, Values.Names.Length)];
		surname = Values.Surnames [Random.Range (0, Values.Surnames.Length)];

		level = 0;
		days = 0;

		laziness = Random.Range (0f, 0.4f);
		efficiency = Random.Range (0.5f, 0.7f);
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
		laziness = Mathf.Clamp (laziness - 0.07f, 0f, 1f);
		efficiency = Mathf.Clamp (efficiency + 0.1f, 0f, 1f);
		++level;
	}

	public Manager Promote() {
		Manager manager = new Manager ();
		manager.name = name;
		manager.surname = surname;
		manager.efficiency = efficiency;

		return manager;
	}
}
