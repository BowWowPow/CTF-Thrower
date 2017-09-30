using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
	public float decay;
	public float t;
	// Use this for initialization
	void Start () {
		decay = 5.0f;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (t <= decay) {
			t += Time.deltaTime;
		} else {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (!collider.gameObject.GetComponent<Player> ().HasKnife ()) {
			collider.gameObject.GetComponent<Player> ().PickUp ();
			Destroy (this.gameObject);
		}
	}
}
