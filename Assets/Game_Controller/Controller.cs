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

	public int boughtFloors = 0;
	public int maxFloors = 5;
	public int currentWorkersPerFloor = 0;
	public int currentManagersPerFloor = 0;
	public int maxWorkersPerFloor = 20;
	public int maxManagersPerFloor = 1;

	public float baseCostFloor = 1000f;
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

	public void BuyWorker(Worker w) {
		if (workers.Count > boughtFloors * currentWorkersPerFloor) return;
		workers.Add (w);
	}
	public void BuyManager(Manager m) {
		if (managers.Count > boughtFloors * currentManagersPerFloor) return;
		managers.Add (m);
	}

	[Header("ETT")]
	public int currentEttWorkers = 0;
	public int currentEttManagers = 0;
	public int maxEttWorkers = 10;
	public int maxEttManagers = 3;
	public float baseCostEttWorkers = 10f;
	public float baseCostEttManagers = 50f;
	public Worker[] ettWorkers;
	public Manager[] ettManagers;

	public void GetNewEttWorkers() {
		if (ettWorkers.Length != currentEttWorkers)
			ettWorkers = new Worker[currentEttWorkers];
		for (int i = 0; i < ettWorkers.Length; ++i)
			ettWorkers [i] = new Worker ();
	}
	public void GetNewEttManagers() {
		if (ettManagers.Length != currentEttManagers)
			ettManagers = new Manager[currentEttManagers];
		for (int i = 0; i < ettManagers.Length; ++i)
			ettManagers [i] = new Manager ();
	}

	//Bank

	//Stock-Market

	//Mafia


}
