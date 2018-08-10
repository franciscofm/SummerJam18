using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerDownHandler {

	public GameObject menuPrefab;
	public enum Side {
		Left,
		Right
	};
	public Side side;

	// Use this for initialization
	void Start () {
		
	}

	public void OnPointerDown(PointerEventData data) {
		Menus.instance.OpenMenu (side == Side.Left, menuPrefab);
	}

}
