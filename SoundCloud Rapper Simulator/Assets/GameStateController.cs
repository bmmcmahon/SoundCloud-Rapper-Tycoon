using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	private GameState gameState;
	private UnityEngine.UI.InputField textField;
	public bool counting;
	public int ttd;

	private Text money;
	private Text stuff;
	private Text followers;
	private Text scoreRundown;
	private Text yourSong;
	private Text songScore;
	private Text songList;
	private Text computerPrice;
	private Text microphonePrice;
	private Text producerPrice;
	private Text computerLevel;
	private Text microphoneLevel;
	private Text producerLevel;

	private MenuEnabler menuEn;
	private int count;

	// Use this for initialization
	void Start () {
		counting = false;
		ttd = 0;
		gameState = new GameState ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
		menuEn = GetComponent<MenuEnabler> ();

		money = GameObject.Find ("/Stats/Panel/Money").GetComponent<Text> ();
		stuff = GameObject.Find ("/Stats/Panel/Stuff").GetComponent<Text> ();
		followers = GameObject.Find ("/Stats/Panel/Followers").GetComponent<Text> ();
		scoreRundown = GameObject.Find ("/ScoreWindow/Panel/ScoreRundown").GetComponent<Text> ();
		yourSong = GameObject.Find ("/ScoreWindow/Panel/Your Song").GetComponent<Text> ();
		songScore = GameObject.Find ("/ScoreWindow/Panel/Score").GetComponent<Text> ();
		songList = GameObject.Find ("/SongList/Panel/Text").GetComponent<Text> ();
		computerPrice = GameObject.Find ("/UpgradeMenu/Panel/ComputerPrice").GetComponent<Text> ();
		microphonePrice = GameObject.Find ("/UpgradeMenu/Panel/MicrophonePrice").GetComponent<Text> ();
		producerPrice = GameObject.Find ("/UpgradeMenu/Panel/ProducerPrice").GetComponent<Text> ();
		computerLevel = GameObject.Find ("/UpgradeMenu/Panel/ComputerLevel").GetComponent<Text> ();
		microphoneLevel = GameObject.Find ("/UpgradeMenu/Panel/MicrophoneLevel").GetComponent<Text> ();
		producerLevel = GameObject.Find ("/UpgradeMenu/Panel/ProducerLevel").GetComponent<Text> ();

		songList.text = "";
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

	public void upgradeMicrophone ()
	{
		gameState.Microphone.levelUp (gameState);
	}

	public void upgradeComputer ()
	{
		gameState.Computer.levelUp (gameState);
	}

	public void upgradeProducer ()
	{
		gameState.Producer.levelUp (gameState);
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
		if(money.text != null) money.text = gameState.Money.ToString ();
		if (gameState.Money < 0) {
			counting = true;
			money.color = Color.red;
		} else {
			counting = false;
			money.color = Color.yellow;
			ttd = 0;
		}
		followers.text = gameState.Followers.ToString ();
		updatePrices ();
	}

	private void updatePrices ()
	{
		computerPrice.text = gameState.Computer.Cost.ToString ();
		microphonePrice.text = gameState.Microphone.Cost.ToString ();
		producerPrice.text = gameState.Producer.Cost.ToString ();
		computerLevel.text = "Lv. " + gameState.Computer.Level.ToString () + " -> Lv. " + (gameState.Computer.Level + 1).ToString ();
		producerLevel.text = "Lv. " + gameState.Producer.Level.ToString () + " -> Lv. " + (gameState.Producer.Level + 1).ToString ();
		microphoneLevel.text = "Lv. " + gameState.Microphone.Level.ToString () + " -> Lv. " + (gameState.Microphone.Level + 1).ToString ();
	}

	private void setUpSongList ()
	{
		songList.text = "";
		foreach (var song in gameState.Songs) {
			string name = song.Title;
			string listens = song.Listeners.ToString();
			songList.text += "Song \""+ name +"\" has " + listens + " listens.\n";
		}
	}

	void updateSongs ()
	{
		gameState.updateSongs ();
		setUpSongList ();
		Debug.Log (" PISS ");
		if (counting) {
			++ttd;
			if (ttd >= 10) {
				menuEn.openGameOver ();
			}
		}
	}




}
