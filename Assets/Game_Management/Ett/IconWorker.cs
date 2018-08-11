using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconWorker : MonoBehaviour, IPointerUpHandler {

	public Text name;
	public Text laziness, efficiency;

	public int i;
	public Worker worker;
	public Ett panel;
	public bool bought;

	public void OnPointerUp(PointerEventData data) {
		if (bought) return;
		panel.BuyWorker (i, this);
		if (bought) GetComponent<Image> ().color = Color.gray;
	}

}
