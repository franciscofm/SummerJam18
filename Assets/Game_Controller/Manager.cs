using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager {

	public int level;
	public int days;

	public string name;
	public string surname;

	public float efficiency; //multiplicador para lo que se gana
	public float proficiency; 
	public float coworking;

	public Manager() {
		name = Values.Names [Random.Range (0, Values.Names.Length)];
		surname = Values.Surnames [Random.Range (0, Values.Surnames.Length)];

		level = 0;
		days = 0;

		proficiency = Random.Range (0f, 0.4f);
		efficiency = Random.Range (0.7f, 0.75f);
		coworking = Random.Range (0.5f, 0.6f);
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
		proficiency = Mathf.Clamp (proficiency + 0.05f, 0f, 1f);
		efficiency = Mathf.Clamp (efficiency + 0.03f, 0f, 1f);
		coworking = Mathf.Clamp (coworking + 0.05f, 0f, 1f);
		++level;
	}
}
