using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

	private float health, decay, th, baseSize;
	private string capture;
	Transform xt, yt;
	// Use this for initialization
	void Start () {
		health = 30.0f;
		th = 10.0f;
		decay = 5.0f;
		capture = null;
		baseSize = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
			GameObject gm = GameObject.FindGameObjectWithTag ("Manager");
			gm.GetComponent<GameManager> ().FlagCanSpawn ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("ENTER TRIGGER");
		if (collider.gameObject.tag == "p1") {
			CapP1 ();
			SetColourFromPlayer (collider.gameObject);
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p2") {
			CapP2 ();
			SetColourFromPlayer (collider.gameObject);
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p3") {
			CapP3 ();
			SetColourFromPlayer (collider.gameObject);
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p4") {
			CapP4 ();
			SetColourFromPlayer (collider.gameObject);
			RemoveHealthAndAddPoints (collider.gameObject);
		}

	}

	void OnTriggerStay2D(Collider2D collider){
		Debug.Log ("STAY TRIGGER");
		if (collider.gameObject.tag == "p1") {
			CapP1 ();
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p2") {
			CapP2 ();
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p3") {
			CapP3 ();
			RemoveHealthAndAddPoints (collider.gameObject);
		}

		if (collider.gameObject.tag == "p4") {
			CapP4 ();
			RemoveHealthAndAddPoints (collider.gameObject);
		}
	}

	void OnTriggerExit2D(){
		Debug.Log (health);
		CapDefault ();
		SetColourToDefault ();
	}


	private void CapDefault(){
		capture = null;
	}

	private void CapP1(){
		capture = "p1";
	}

	private void CapP2(){
		capture = "p2";
	}

	private void CapP3(){
		capture = "p3";
	}

	private void CapP4(){
		capture = "p4";
	}

	private void RemoveHealthAndAddPoints(GameObject player){
		float _d = decay * Time.deltaTime;
		health -= _d;
		UpdateTransformSize ();
		player.GetComponent<Player> ().AddPoints (_d);
		Debug.Log (health);
	}

	private void UpdateTransformSize(){
		float ratio = health / th;
		float xy = baseSize * ratio;
		this.gameObject.transform.localScale = new Vector2 (xy, xy);
	}

	private void SetColourFromPlayer(GameObject player){
		Color c = player.GetComponent<SpriteRenderer>().color;
		this.gameObject.GetComponent<SpriteRenderer> ().color = c;
	}

	private void SetColourToDefault(){
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
	}
}
