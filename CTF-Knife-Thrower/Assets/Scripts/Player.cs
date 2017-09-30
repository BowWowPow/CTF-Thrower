using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed, points,knifeCD,kt, angle;
	public int player_n;
	public bool hasKnife;
	public GameObject knife;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		moveSpeed = 0.5f;
		knifeCD = 3.0f;
		kt = 0.0f;
		angle = 0.0f;
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		MovePlayer ();
		RotatePlayer ();
		if (!HasKnife ()) {
			if (kt <= knifeCD) {
				kt += Time.deltaTime;
			} else {
				PickUp ();
				kt = 0;
			}
		}
	}
		

	public void MovePlayer(){
		//Debug.Log ("MOVING PLAYER : " + player_n.ToString ());
		string horz = "h" + player_n.ToString ();
		string vert = "v" + player_n.ToString ();
		float h = Input.GetAxis (horz);
		float v = Input.GetAxis (vert);
		transform.Translate(new Vector3 (moveSpeed * v * Time.deltaTime,moveSpeed * h * Time.deltaTime,0.0f)); 
		//rb.velocity = new Vector2 (moveSpeed * v,moveSpeed * h);
	}

	public void RotatePlayer(){
		float rightInputY = Input.GetAxis("h"+player_n.ToString() + "r");
		float rightInputX = Input.GetAxis("v"+player_n.ToString() + "r");
		Vector2 aimDirection = new Vector2(rightInputY, rightInputX);

		angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
		//this.transform.rotation = Quaternion.LookRotation (new Vector3(0.0f,angle,0.0f));
		//this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		//rb.MoveRotation(angle);
		//transform.rotation = Quaternion.Euler(0f,0f,angle);
		transform.localEulerAngles = new Vector3(0.0f,0.0f,-angle);

//		float deadzone = 0.25f;
//		Vector2 stickInput = new Vector2(rightInputX, rightInputY);
//		if (stickInput.magnitude < deadzone) {
//			stickInput = Vector2.zero;
//		}
//		this.transform.rotation = Quaternion.LookRotation (stickInput, Vector3.back);
	}

	public void SetPlayer(int i){
		//Debug.Log ("SETTING PLAYER NUMBER : " + i.ToString());
		player_n = i;
	}

	public void FireKnife(){
		GameObject _knife = Instantiate (knife, this.gameObject.transform.position, this.gameObject.transform.rotation);
		Rigidbody2D krb = _knife.GetComponent<Rigidbody2D> ();
	
	}

	public int GetPlayer(){
		return player_n;
	}

	public void AddPoints(float p){
		points += p;
	}

	public void PickUp(){
		hasKnife = true;
	}

	public bool HasKnife(){
		return hasKnife;
	}
}
