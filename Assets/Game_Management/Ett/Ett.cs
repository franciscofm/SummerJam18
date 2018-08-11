using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ett : BuildingPanel {

	public Transform firstWorkerRow, secondWorkerRow;
	public GameObject iconWorkerPrefab, iconManagerPrefab;

	public override void UpdateValues () {

		while (firstWorkerRow.childCount > 0)
			Destroy (firstWorkerRow.GetChild (0).gameObject);
		while (secondWorkerRow.childCount > 0)
			Destroy (secondWorkerRow.GetChild (0).gameObject);
		
		int i;
		for (i = 0; i < 5 && i < Controller.instance.ettWorkers.Length; ++i) {
			IconWorker icon = Instantiate (iconWorkerPrefab, firstWorkerRow).GetComponent<IconWorker> ();
			icon.i = i;
			icon.worker = Controller.instance.ettWorkers[i];
			icon.name.text = icon.worker.name;
			icon.laziness.text = icon.worker.laziness + "";
			icon.efficiency.text = icon.worker.efficiency + "";
			icon.bought = Controller.instance.ettWorkersBought [i];
		}
		for ( ; i < Controller.instance.ettWorkers.Length; ++i) {
			IconWorker icon = Instantiate (iconWorkerPrefab, secondWorkerRow).GetComponent<IconWorker> ();
			icon.i = i;
			icon.worker = Controller.instance.ettWorkers[i];
			icon.name.text = icon.worker.name;
			icon.laziness.text = icon.worker.laziness + "";
			icon.efficiency.text = icon.worker.efficiency + "";
			icon.bought = Controller.instance.ettWorkersBought [i];
		}
	}

	public void BuyWorker(int i, IconWorker icon) {
		if (Controller.instance.BuyWorker (i)) icon.bought = true;
	}
}
