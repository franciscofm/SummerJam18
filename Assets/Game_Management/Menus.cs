using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour {

	public static Menus instance;

	public RectTransform leftPanel, rightPanel;
	public RectTransform barPanel;

	public Vector2 leftHide, leftShow;
	public Vector2 rightHide, rightShow;
	public Vector2 barHide, barShow;

	// Use this for initialization
	void Awake() {
		instance = this;
	}

	void Start () {
		Canvas.ForceUpdateCanvases ();

		leftHide = leftShow = leftPanel.position;
		leftHide.x -= leftPanel.rect.width;
		leftPanel.position = leftHide;

		rightHide = rightShow = rightPanel.position;
		rightHide.x += rightPanel.rect.width;
		rightPanel.position = rightHide;

		barHide = barShow = barPanel.position;
		barHide.y += barPanel.rect.height * 0.5f;
		barPanel.position = barHide;

	}

	public void OpenMenu(bool left, GameObject menu) {
		RectTransform target = left ? leftPanel : rightPanel;

		if (target.childCount != 0) 
			Destroy (target.GetChild (0).gameObject);


	}
}
