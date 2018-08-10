using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	public GameObject menuPrefab;
	public enum Side {
		Left,
		Right
	};
	public Side side;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		down = false;
	}


	bool down;
	public void OnPointerDown(PointerEventData data) {
		animator.Play ("Select");
		down = true;
	}
	public void OnPointerUp(PointerEventData data) {
		Menus.instance.OpenMenu (side == Side.Left, menuPrefab, GetInstanceID());
		if (down) {
			animator.Play ("Unselect");
			down = false;
		}
	}
	public void OnPointerExit(PointerEventData data) {
		if (down) {
			animator.Play ("Unselect");
			down = false;
		}
	}

}
