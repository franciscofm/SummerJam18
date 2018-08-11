using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedDeskRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Transform[] decorationObjects = this.GetComponentsInChildren<Transform> ();
		for (int i = 0; i < decorationObjects.Length; i++) {
			if (Random.value < 0.5f) {
				decorationObjects [i].gameObject.SetActive (false);
			}
		}
	}
}
