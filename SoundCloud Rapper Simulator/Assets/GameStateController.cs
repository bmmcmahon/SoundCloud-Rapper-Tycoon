using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	private GameState gameState;
	private UnityEngine.UI.InputField textField;

	private Text money;
	private Text stuff;
	private Text followers;
	private Text scoreRundown;
	private Text yourSong;
	private Text songScore;

	private MenuEnabler menuEn;
	private int count;

	// Use this for initialization
	void Start () {
		gameState = new GameState ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
		menuEn = GetComponent<MenuEnabler> ();

		money = GameObject.Find ("/Stats/Panel/Money").GetComponent<Text> ();
		stuff = GameObject.Find ("/Stats/Panel/Stuff").GetComponent<Text> ();
		followers = GameObject.Find ("/Stats/Panel/Followers").GetComponent<Text> ();
		scoreRundown = GameObject.Find ("/ScoreWindow/Panel/ScoreRundown").GetComponent<Text> ();
		yourSong = GameObject.Find ("/ScoreWindow/Panel/Your Song").GetComponent<Text> ();
		songScore = GameObject.Find ("/ScoreWindow/Panel/Score").GetComponent<Text> ();
		scoreRundown.enabled = false;
		songScore.enabled = false;

		Debug.Log (money.text);
		InvokeRepeating("updateSongs", 0f, 30f);
	}

	public void songCreated ()
	{
		double score = gameState.produceSong (textField.text);
		yourSong.text = "\"" + textField.text + "\"" + " is...";
		textField.text = "";
		Debug.Log (score.ToString());
		if (score < 3) {
			scoreRundown.text = "confirmed trash.";
		} else if (score < 5) {
			scoreRundown.text = "a tragic disappointment.";
		} else if (score < 8) {
			scoreRundown.text = "pretty good!";
		} else if (score < 10) {
			scoreRundown.text = "a HIT!";
		} else if (score == 10) {
			scoreRundown.text = "a MASTAPIECE!";
		}
		songScore.text = score + "/10";
		menuEn.closeCreators ();
		menuEn.openScoreWindow ();
	}

	public void scoreWindowContinue() 
	{
		if (scoreRundown.enabled) {
			menuEn.closeScoreWindow ();
		}
		flipScoreRundownEnabled ();

	}
//
	public void flipScoreRundownEnabled ()
	{
		if (scoreRundown.enabled) {
			scoreRundown.enabled = false;
			songScore.enabled = false;
		} else {
			scoreRundown.enabled = true;
			songScore.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		money.text = gameState.Money.ToString ();
		followers.text = gameState.Followers.ToString ();
	}

	void updateSongs ()
	{
		gameState.updateSongs ();
		Debug.Log (" PISS ");
	}
}
