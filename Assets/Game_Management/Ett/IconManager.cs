using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

	public Text name;
	public Text laziness, efficiency;

	public int i;
	public Manager manager;
	public Ett panel;
	public bool bought;

	public void OnPointerUp() {
		if (bought) return;
		panel.BuyManager (i, this);
		if (bought) GetComponent<Image> ().color = Color.gray;
	}

}
