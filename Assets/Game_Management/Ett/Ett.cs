using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ett : BuildingPanel {

	public Text maxWorkers, maxManagers;
	public Text raiseWorkers, raiseManagers;

	public Transform firstWorkerRow, secondWorkerRow;
	public Transform managerRow;
	public GameObject iconWorkerPrefab, iconManagerPrefab;

	public override void UpdateValues () {

		maxWorkers.text = Controller.instance.currentEttWorkers + "";
		maxManagers.text = Controller.instance.currentEttManagers + "";
		raiseWorkers.text = Mathf.Pow (Controller.instance.baseCostEttWorkers, (float) Controller.instance.currentEttWorkers) + "";
		raiseManagers.text = Mathf.Pow (Controller.instance.baseCostEttManagers, (float) Controller.instance.currentEttManagers) + "";

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
			icon.laziness.text = icon.worker.laziness.ToString("0.00");
			icon.efficiency.text = icon.worker.efficiency.ToString("0.00");
			icon.bought = Controller.instance.ettWorkersBought [i];
			icon.panel = this;
		}
		for ( ; i < Controller.instance.ettWorkers.Length; ++i) {
			IconWorker icon = Instantiate (iconWorkerPrefab, secondWorkerRow).GetComponent<IconWorker> ();
			icon.i = i;
			icon.worker = Controller.instance.ettWorkers[i];
			icon.name.text = icon.worker.name;
			icon.laziness.text = icon.worker.laziness.ToString("0.00");
			icon.efficiency.text = icon.worker.efficiency.ToString("0.00");
			icon.bought = Controller.instance.ettWorkersBought [i];
			icon.panel = this;
		}

		for (i = 0; i < 5 && i < Controller.instance.ettManagers.Length; ++i) {
			IconManager icon = Instantiate (iconManagerPrefab, managerRow).GetComponent<IconManager> ();
			icon.i = i;
			icon.manager = Controller.instance.ettManagers[i];
			icon.name.text = icon.manager.name;
			icon.laziness.text = icon.manager.proficiency.ToString("0.00");
			icon.efficiency.text = icon.manager.efficiency.ToString("0.00");
			icon.bought = Controller.instance.ettManagersBought [i];
			icon.panel = this;
		}
	}

	public void BuyWorker(int i, IconWorker icon) {
		if (Controller.instance.BuyWorker (i)) icon.bought = true;
	}
	public void BuyManager(int i, IconManager icon) {
		if (Controller.instance.BuyManager (i)) icon.bought = true;
	}
}
