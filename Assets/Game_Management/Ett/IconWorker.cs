using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class IconWorker : MonoBehaviour, IPointerUpHandler{

	public Worker worker;
	public Ett panel;
	public bool bought;

	public void OnPointerUp(PointerEventData data) {
		if (bought) return;

	}

}
