using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject p1,p2,p3,p4,sp1,sp2,sp3,sp4,fs1,fs2,fs3,fs4,fs5,flag;
	private List<GameObject> Players = new List<GameObject>();
	private List<GameObject> Spawns = new List<GameObject>();
	private List<GameObject> Flags = new List<GameObject>();
	private GameObject _p1;
	private GameObject _p2;
	private GameObject _p3;
	private GameObject _p4;
	private GameObject _flag;
	private bool flagSpawn;

	void Start(){
		flagSpawn = true;
		_p1 = new GameObject ("p1");
		_p2 = new GameObject ("p2");
		_p3 = new GameObject ("p3");
		_p4 = new GameObject ("p4");
		_p1 = Instantiate (p1, sp1.transform.position,sp1.transform.rotation);
		_p2 = Instantiate (p2, sp2.transform.position,sp2.transform.rotation);
		_p3 = Instantiate (p3, sp3.transform.position,sp3.transform.rotation);
		_p4 = Instantiate (p4, sp4.transform.position,sp4.transform.rotation);

		//Debug.Log ("SETTING PLAYER NUMBER");
		_p1.GetComponent<Player> ().SetPlayer (0);
		_p2.GetComponent<Player> ().SetPlayer (1);
		_p3.GetComponent<Player> ().SetPlayer (2);
		_p4.GetComponent<Player> ().SetPlayer (3);

		Players.Add (_p1);
		Players.Add (_p2);
		Players.Add (_p3);
		Players.Add (_p4);

		//Debug.Log ("Player Count : " + Players.Count);

		Spawns.Add (sp1);
		Spawns.Add (sp2);
		Spawns.Add (sp3);
		Spawns.Add (sp4);


		Flags.Add (fs1);
		Flags.Add (fs2);
		Flags.Add (fs3);
		Flags.Add (fs4);
		Flags.Add (fs5);

		int r = Random.Range (0, 4);
		_flag = Instantiate (flag, Flags [r].transform.position, Flags [r].transform.rotation);
		flagSpawn = false;
	}

	void FixedUpdate(){
		if(CanFlagSpawn ()){
			SpawnAFlag ();
		}
	}

	public bool CanFlagSpawn(){
		return flagSpawn;
	}

	private void SpawnAFlag(){
		int r = Random.Range (0, Flags.Count);
		_flag = Instantiate (flag, Flags [r].transform.position, Flags [r].transform.rotation);
		flagSpawn = false;
	}

	public void FlagCanSpawn(){
		flagSpawn = true;
	}
}
