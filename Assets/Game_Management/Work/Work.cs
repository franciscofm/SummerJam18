using UnityEngine;
using UnityEngine.UI;

public class Work : BuildingPanel {

	public Text hiredWorkers;
	public Text incomeWorkers;

	public Text hiredManagers;
	public Text ratioManagers;

	public Text boughtFloors;
	public Text workersPerFloor;
	public Text managersPerFloor;

	public Text buyFloor;
	public Text buyWorkerPerFloor;
	public Text buyManagerPerFloor;

	public override void UpdateValues () {
		hiredWorkers.text = Controller.instance.workers.Count + "";
		incomeWorkers.text = Controller.instance.baseIncomePerGameWorker + "";

		hiredManagers.text = Controller.instance.managers.Count + "";
		float ratio = 1f;
		foreach (Manager m in Controller.instance.managers)
			ratio *= m.efficiency;
		ratioManagers.text = ratio.ToString("0.00");

		boughtFloors.text = Controller.instance.boughtFloors + "";
		workersPerFloor.text = Controller.instance.currentWorkersPerFloor + "";
		managersPerFloor.text = Controller.instance.currentManagersPerFloor + "";

		buyFloor.text = Mathf.Pow (Controller.instance.baseCostFloor, 1f + Controller.instance.boughtFloors) + "";
		buyWorkerPerFloor.text = Mathf.Pow (Controller.instance.baseCostWorkersPerFloor, 1f + Controller.instance.currentWorkersPerFloor) + "";
		buyManagerPerFloor.text = Mathf.Pow (Controller.instance.baseCostManagersPerFloor, 1f + Controller.instance.currentManagersPerFloor) + "";
	}

	public void BuyFloor() {
		if (Controller.instance.BuyFloor ()) UpdateValues ();
	}
	public void BuyWorkerPerFloor() {
		if (Controller.instance.BuyWorkerPerFloor ()) UpdateValues ();
	}
	public void BuyManagerPerFloor() {
		if (Controller.instance.BuyManagerPerFloor ()) UpdateValues ();
	}
}
