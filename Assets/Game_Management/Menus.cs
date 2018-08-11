using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour {

	public static Menus instance;

	public RectTransform leftPanel, rightPanel;
	public RectTransform barPanel;

	public float animationDuration = 0.5f;
	public AnimationCurve animationCurve;

	Vector2 leftHide, leftShow;
	Vector2 rightHide, rightShow;
	Vector2 barHide, barShow;

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

	IEnumerator leftRoutine, rightRoutine;
	GameObject leftObject, rightObject;
	int leftId, rightId;

	public void OpenMenu(bool left, GameObject menu, int id) {
		RectTransform target = left ? leftPanel : rightPanel;
		if (left) {
			target = leftPanel;
			if(leftRoutine != null) StopCoroutine (leftRoutine);
			if(leftObject != null) Destroy (leftObject);
			StartCoroutine (leftRoutine = Utils.MoveRoutine2 (target, target.position, leftShow, animationDuration, animationCurve));
		} else {
			target = rightPanel;
			if(rightRoutine != null) StopCoroutine (rightRoutine);
			if(rightObject != null) Destroy (rightObject);
			StartCoroutine (rightRoutine = Utils.MoveRoutine2 (target, target.position, rightShow, animationDuration, animationCurve));
		}

		if (left) {
			if (leftId == id) return;
			else leftId = id;
		} else {
			if (rightId == id) return;
			else rightId = id;
		}

		Instantiate (menu, target).GetComponent<BuildingPanel>().UpdateValues();
	}
	public void CloseMenu(bool left) {
		if (left) {
			if(leftRoutine != null) StopCoroutine (leftRoutine);
			StartCoroutine (leftRoutine = Utils.MoveRoutine2 (leftPanel, leftPanel.position, leftHide, animationDuration, animationCurve));
		} else {
			if(rightRoutine != null) StopCoroutine (rightRoutine);
			StartCoroutine (rightRoutine = Utils.MoveRoutine2 (rightPanel, rightPanel.position, rightHide, animationDuration, animationCurve));
		}
	}

	public void OpenBar() {

	}
	public void CloseBar() {

	}
}
