using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEnabler : MonoBehaviour {

	private Canvas songCreator;
	private Canvas videoCreator;
	private Transform transform;
	private Animator animator;
	private Canvas scoreWindow;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find ("SongCreator");
		transform = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
		if(temp != null){
			songCreator = temp.GetComponent<Canvas>();
			if(songCreator == null){
				Debug.Log("Could not locate Canvas component on " + temp.name);
			}
		}
		songCreator.enabled = false;
		temp = GameObject.Find ("VideoCreator");
		if(temp != null){
			videoCreator = temp.GetComponent<Canvas>();
			if(videoCreator == null){
				Debug.Log("Could not locate Canvas component on " + temp.name);
			}
		}
		scoreWindow = GameObject.Find ("ScoreWindow").GetComponent<Canvas> ();
		scoreWindow.enabled = false;
		videoCreator.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < -5f && transform.position.y > -1f) {
			if (Input.GetKey (KeyCode.A)) {
				openSongCreator ();
			}
		}
		if (transform.position.x > 5.53f && transform.position.y > -1.03f) {
			if (Input.GetKey (KeyCode.A)) {
				openVideoCreator ();
			}
		}
//		if (Input.GetKey (KeyCode.B)) {
//			closeCreators ();
//		}
	}
	public void openScoreWindow ()
	{
		scoreWindow.enabled = true;
	}

	public void closeScoreWindow ()
	{
		scoreWindow.enabled = false;
	}

	public void closeCreators () {
		songCreator.enabled = false;
		videoCreator.enabled = false;
		animator.SetBool ("CanWalk", true);
	}

	public void openSongCreator () {
		songCreator.enabled = true;
		animator.SetBool ("CanWalk", false);
	}

	public void openVideoCreator () {
		videoCreator.enabled = true;
		animator.SetBool ("CanWalk", false);
	}
}
