using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
	public SpriteRenderer[] S;
	public GameObject endTime;
	private Vector3 first,last;
	// Use this for initialization
	void Start () {
		first = endTime.transform.position;
		last.Set (first.x-10, first.y, first.z);
	}
	public void start(){
		SceneManager.LoadScene ("Orbs&Holes");
	}
	public void menu(){
		SceneManager.LoadScene ("menu");
	}
	public void Exit(){
		Application.Quit ();
	}
	public void EndingWithSetStars(int n)
	{
		endTime.transform.position = last;

		for(int i=0;i<4;i++)
			if(i < n){
				S[i].enabled =  true;
			}
			else{
				S[i].enabled =  false;
			}
	}	// Update is called once per frame
	void Update () {
		
	}
}
