﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class IconWorker : MonoBehaviour {

	public Text name;
	public Text laziness, efficiency;

	public int i;
	public Worker worker;
	public Ett panel;
	public bool bought;

	public void OnPointerUp() {
		if (bought) return;
		print ("OnPointerUp");
		panel.BuyWorker (i, this);
		if (bought) GetComponent<Image> ().color = Color.gray;
	}

}
