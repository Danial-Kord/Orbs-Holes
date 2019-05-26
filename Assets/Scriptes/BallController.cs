using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallController : MonoBehaviour {
	[SerializeField] private SpriteRenderer[] joons;
	private Vector3 firstPosision;
	private Controller controller;
	public LevelManager levelManager;
	[SerializeField] private Button upR, upL, downR, downL;
	bool reseting = false;
	bool end=false;
	int win =0;
	/// <summary>
	/// T//////////////////////////////	/// </summary>
	//tabsell
	//ppv pay per view
	// ppc click
	//good site : gamasutra.com
	//shomare : 09100056359
	//ketab : art of game design
	/// <summary>
	/// T///////////////////	/// </summary>
	int health = 4;
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<Controller> ();
		PlayerStats p1 = new PlayerStats();
		p1.id = "22";
		p1.name = "ali";
		p1.score = "20";
		p1.ping = "26161";
		string playerJason = JsonUtility.ToJson (p1);

		PlayerStats p2 = new PlayerStats ();
		p2 = JsonUtility.FromJson<PlayerStats> (playerJason);
	}
	
	// Update is called once per frame
	void Update () {
	}
	//backtory.com //
	// abring
	//servise haye online mese serialize vo ina
	public void loseHealth(bool input){
		if (health == 0 && reseting) {
			return;
		}
		if (input) {
			joons [health - 1].color = Color.gray;
			health--;	
			if (health == 0) {
				levelManager.EndingWithSetStars (0);
				end = true;
				controller.setEnd (true);
			}
		} else {
			win++;
			if (win == 3) {
				end = true;
				levelManager.EndingWithSetStars (health-1);
				controller.setEnd (true);
			}
		}
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		this.transform.position = firstPosision;

		controller.reset ();
		reseting = true;
	}
	public void reset(){
		GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

		reseting = false;
	}

}
