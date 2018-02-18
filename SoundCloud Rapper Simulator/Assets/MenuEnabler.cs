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
	private Canvas songList;
	private Canvas upgradeMenu;
	private AudioSource overworldMusic;
	private AudioSource creatorMusic;
	private Canvas gameOver;
	private Canvas notEnoughMoney;
	private Canvas videoScoreWindow;
	private Canvas feedBackScreen;

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
		songList = GameObject.Find ("SongList").GetComponent<Canvas> ();
		upgradeMenu = GameObject.Find ("UpgradeMenu").GetComponent<Canvas> ();
		overworldMusic = GameObject.Find ("OverworldMusic").GetComponent<AudioSource>();
		creatorMusic = GameObject.Find ("CreatorMusic").GetComponent<AudioSource> ();
		gameOver = GameObject.Find ("GameOver").GetComponent<Canvas> ();
		notEnoughMoney = GameObject.Find ("NotEnoughMoney").GetComponent<Canvas> ();
		videoScoreWindow = GameObject.Find ("VideoScoreWindow").GetComponent<Canvas> ();
		feedBackScreen = GameObject.Find ("FeedBackScreen").GetComponent<Canvas> ();
		feedBackScreen.enabled = false;
		videoScoreWindow.enabled = false;
		notEnoughMoney.enabled = false;
		gameOver.enabled = false;
		upgradeMenu.enabled = false;
		songList.enabled = false;
		scoreWindow.enabled = false;
		videoCreator.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < -5f && transform.position.y > -1f && !scoreWindow.enabled) {
			if (Input.GetKey (KeyCode.A)) {
				openSongCreator ();
			}
		}
		if (transform.position.x > 5.53f && transform.position.y > -1.03f && !scoreWindow.enabled) {
			if (Input.GetKey (KeyCode.A)) {
				openVideoCreator ();
			}
		}
		if (transform.position.x > 6.14f && transform.position.y < -.76f) {
			if (Input.GetKey (KeyCode.A)) {
				openSongList ();
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

	public void openVideoScoreWindow()
	{
		videoScoreWindow.enabled = true;
	}

	public void closeScoreWindow ()
	{
		scoreWindow.enabled = false;
	}

	public void closeVideoScoreWindow ()
	{
		videoScoreWindow.enabled = false;
	}

	public void openSongList ()
	{
		songList.enabled = true;
		closeUpgradeMenu ();
	}

	public void openUpgradeMenu ()
	{
		upgradeMenu.enabled = true;
	}

	public void closeUpgradeMenu ()
	{
		upgradeMenu.enabled = false;
	}

	public void closeSongList ()
	{
		songList.enabled = false;
	}

	public void closeCreators () {
		songCreator.enabled = false;
//		defaultVals ();
		videoCreator.enabled = false;
		animator.SetBool ("CanWalk", true);
		stopCreatorMusic ();
		playOverworldMusic ();
	}

//	public void default vals

	public void openSongCreator () {
		songCreator.enabled = true;
		animator.SetBool ("CanWalk", false);
		stopOverworldMusic ();
		playCreatorMusic ();
	}

	public void openVideoCreator () {
		videoCreator.enabled = true;
		animator.SetBool ("CanWalk", false);
		stopOverworldMusic ();
		playCreatorMusic ();
	}

	public void stopOverworldMusic () {
		overworldMusic.enabled = false;
	}

	public void playOverworldMusic () {
		overworldMusic.enabled = true;
	}

	public void stopCreatorMusic () {
		creatorMusic.enabled = false;
	}

	public void playCreatorMusic () {
		creatorMusic.enabled = true;
	}

	public void openGameOver ()
	{
		gameOver.enabled = true;
		animator.SetBool ("CanWalk", false);
	}

	public void openNotEnoughMoney ()
	{
		notEnoughMoney.enabled = true;
	}

	public void closeNotEnoughMoney ()
	{
		notEnoughMoney.enabled = false;
	}

	public void openFeedBackScreen()
	{
		feedBackScreen.enabled = true;
	}

	public void closeFeedBackScreen()
	{
		feedBackScreen.enabled = false;
	}
}
