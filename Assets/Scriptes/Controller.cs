using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour {

	Vector3 initialposision;
	[SerializeField] private GameObject maximumPosision;
	[SerializeField] private GameObject minimumPosision;
	private bool reseting = false;
	Rigidbody2D rb;
	private bool end=false;
	// Use this for initialization
	void Start () {
		initialposision = transform.position;
		rb = GetComponent<Rigidbody2D> ();
	}
	public void setEnd(bool i){
		end = i;
	}
	// Update is called once per frame
	void Update () {
		if (end)
			return;
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.E)&& (transform.position.y < maximumPosision.transform.position.y) && !reseting) {
			rb.angularVelocity = 0;
			rb.velocity = Vector2.up * 2;
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && (transform.position.y > minimumPosision.transform.position.y) && !reseting) {
			rb.angularVelocity = 0;
			rb.velocity = Vector2.down * 2;
		} else {
			if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) && !reseting) {
				if ((transform.rotation.eulerAngles.z>=350 && transform.rotation.eulerAngles.z<=360) ||transform.rotation.eulerAngles.z <= 10)
					rb.angularVelocity = 5;
				else {
					rb.angularVelocity = 0;
				}
			}
			if ((Input.GetKey (KeyCode.E)|| Input.GetKey (KeyCode.D)) && !reseting) { 
				if((transform.rotation.eulerAngles.z>=350 && transform.rotation.eulerAngles.z<=360) || transform.rotation.eulerAngles.z<=10)
				rb.angularVelocity = -5;
				else {
					rb.angularVelocity = 0;
				}
			}
			if (Input.GetKeyUp (KeyCode.W)) {
				rb.angularVelocity = 0;
			}
			if (Input.GetKeyUp (KeyCode.E)) {
				rb.angularVelocity = 0;
			}
		}
		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.E) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)) {
			rb.velocity = Vector3.zero;
		}
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.E) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D) && transform.rotation.z != 0) {
			if (transform.rotation.z != 0) {
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (Vector2.zero), Time.deltaTime*2);
			}
		}
	}
	public void reset(){
		reseting = true;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0;
		StartCoroutine (Reset());
	}
	IEnumerator Reset(){
		bool flag = true;
		while(flag){
			yield return new WaitForSeconds(0.03f);
			if (transform.rotation.z != 0) {
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (Vector2.zero), Time.deltaTime*2);
			}
			if(transform.position.y > minimumPosision.transform.position.y){
				transform.position = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z);
			}
			else
				flag = false;
		}
		BallController ballController = GameObject.FindGameObjectWithTag ("Player").GetComponent<BallController> ();
		ballController.reset ();

		reseting = false;
	}
}
