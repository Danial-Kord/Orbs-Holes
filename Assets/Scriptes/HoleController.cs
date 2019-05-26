using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {
	BallController ballController;
	// Use this for initialization
	void Start () {
		ballController = GameObject.FindGameObjectWithTag ("Player").GetComponent<BallController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag.Equals ("Player") && !this.tag.Equals ("Score")) {
			ballController.loseHealth (true);
		} else if(col.tag.Equals ("Player") &&this.tag.Equals ("Score") && !GetComponent<SpriteRenderer> ().color.Equals (Color.blue)) {
			ballController.loseHealth (false);
			GetComponent<SpriteRenderer> ().color = Color.blue;
		}
	}
}
