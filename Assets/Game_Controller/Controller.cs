using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public static Controller instance;
	
	void Awake() {
		instance = this;
		DontDestroyOnLoad (gameObject);
	}
	void Start() {
		workers = new List<Worker>();
		managers = new List<Manager> ();
		gamesThisMonth = 0;
		progressionMonthly = 1f;
		money = 3000f;

		GetNewEttWorkers ();
		GetNewEttManagers ();
	}

	[Header("General")]
	public int year = 2018;
	public int month = 3;

	public float money;
	bool earnMonthly;
	float progressionMonthly;

	public int gamesThisMonth;
	public int gamesPerMonth = 4;

	public void Play() {
		++gamesThisMonth;
		earnMonthly = false;
		if (gamesThisMonth > gamesPerMonth) {
			earnMonthly = true;
			gamesThisMonth = 0;
			month = (month + 1) % 12;
			if (month == 0) ++year;
		}
	}
	public void FinishPlay(float success) {
		money += EarnDaywork() * success;
		if (earnMonthly) {
			progressionMonthly *= success;
			money += EarnMonthly() * progressionMonthly;
			progressionMonthly = 1f;

			GetNewEttWorkers ();
			GetNewEttManagers ();
		}
	}

	[Header("Office")]
	public float baseIncomePerGame = 100f;
	public float baseIncomePerGameWorker = 20f;

	public float baseIncomePerMonth = 300f;

	public int boughtFloors = 1;
	public int maxFloors = 5;
	public int currentWorkersPerFloor = 2;
	public int currentManagersPerFloor = 0;
	public int maxWorkersPerFloor = 20;
	public int maxManagersPerFloor = 1;

	public float baseCostFloor = 100f;
	public float baseCostWorkersPerFloor = 20f;
	public float baseCostManagersPerFloor = 4000f;

	public List<Worker> workers;
	public List<Manager> managers;
	
	public float EarnDaywork() {
		float total = baseIncomePerGame;
		float lost = 0f;
		foreach (Worker w in workers) {
			total += baseIncomePerGameWorker * w.efficiency;
			lost += baseIncomePerGameWorker * (1f - w.efficiency);
			w.Work ();
		}
		foreach (Manager m in managers) {
			lost *= (1f - m.efficiency);
			m.Work ();
		}
		total += lost;
		return total;
	}
	public float EarnMonthly() {
		return baseIncomePerMonth;
	}

	public bool BuyFloor() {
		if (boughtFloors > maxFloors) return false;
		float cost = Mathf.Pow (baseCostFloor, 1f + boughtFloors);
		if (money < cost) return false;
		money -= cost;
		++boughtFloors;
		return true;
	}
	public bool BuyWorkerPerFloor() {
		if (currentWorkersPerFloor > maxWorkersPerFloor) return false;
		float cost = Mathf.Pow (baseCostWorkersPerFloor, 1f + currentWorkersPerFloor);
		if (money < cost) return false;
		money -= cost;
		++currentWorkersPerFloor;
		return true;
	}
	public bool BuyManagerPerFloor() {
		if (currentManagersPerFloor > maxManagersPerFloor) return false;
		float cost = Mathf.Pow (baseCostManagersPerFloor, 1f + currentManagersPerFloor);
		if (money < cost) return false;
		money -= cost;
		++currentManagersPerFloor;
		return true;
	}

	[Header("ETT")]
	public int currentEttWorkers = 1;
	public int currentEttManagers = 3;
	public int maxEttWorkers = 10;
	public int maxEttManagers = 3;
	public float baseCostEttWorkers = 10f;
	public float baseCostEttManagers = 50f;
	public Worker[] ettWorkers;
	public Manager[] ettManagers;
	public bool[] ettWorkersBought;
	public bool[] ettManagersBought;

	public void GetNewEttWorkers() {
		if (ettWorkers == null || ettWorkers.Length != currentEttWorkers) {
			ettWorkers = new Worker[currentEttWorkers];
			ettWorkersBought = new bool[currentEttWorkers];	
		}
		for (int i = 0; i < ettWorkers.Length; ++i) {
			ettWorkers [i] = new Worker ();
			ettWorkersBought [i] = false;
		}
	}
	public void GetNewEttManagers() {
		if (ettManagers == null || ettManagers.Length != currentEttManagers) {
			ettManagers = new Manager[currentEttManagers];
			ettManagersBought = new bool[currentEttWorkers];	
		}
		for (int i = 0; i < ettManagers.Length; ++i) {
			ettManagers [i] = new Manager ();
			ettManagersBought [i] = false;
		}
	}

	public bool BuyWorker(int i) {
		print (workers.Count + ">=" + boughtFloors + "*" + currentWorkersPerFloor);
		if (workers.Count >= boughtFloors * currentWorkersPerFloor) return false;
		print (money + "<" + Mathf.Pow (baseCostEttWorkers, (float)workers.Count));
		if (money < Mathf.Pow (baseCostEttWorkers, (float) workers.Count)) return false;
		workers.Add (ettWorkers[i]);
		ettWorkersBought [i] = true;
		money -= Mathf.Pow (baseCostEttWorkers, (float)workers.Count);
		return true;
	}
	public bool BuyManager(int i) {
		if (managers.Count > boughtFloors * currentManagersPerFloor) return false;
		if (money < Mathf.Pow (baseCostEttManagers, (float) managers.Count)) return false;
		managers.Add (ettManagers[i]);
		ettManagersBought [i] = true;
		money -= Mathf.Pow (baseCostEttManagers, (float)managers.Count);
		return true;
	}

	//Bank

	//Stock-Market

	//Mafia


}
