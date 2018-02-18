using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	private GameState gameState;
	private UnityEngine.UI.InputField textField;
	public bool counting;
	public int ttd;
	private SongQualities sq;

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
	private Text playerLevel;

	private Dropdown style;
	private Dropdown tempo;
	private Dropdown topic;
	private Dropdown featuring;

	private Dropdown songForVideo;

	private MenuEnabler menuEn;
	private int count;

	// Use this for initialization
	void Start () {
		counting = false;
		ttd = 0;
		gameState = new GameState ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
		menuEn = GetComponent<MenuEnabler> ();
		sq = GetComponent<SongQualities> ();

		style = GameObject.Find ("/SongCreator/Panel/Dropdown").GetComponent<Dropdown> ();
		tempo = GameObject.Find ("/SongCreator/Panel/Dropdown (1)").GetComponent<Dropdown> ();
		topic = GameObject.Find ("/SongCreator/Panel/Dropdown (2)").GetComponent<Dropdown> ();
		featuring = GameObject.Find ("/SongCreator/Panel/Dropdown (3)").GetComponent<Dropdown> ();

		songForVideo = GameObject.Find ("/VideoCreator/Panel/SongForVideo").GetComponent<Dropdown> ();

		playerLevel = GameObject.Find ("/LevelDisplay/Panel/PlayerLevel").GetComponent<Text> ();
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

		songForVideo.ClearOptions ();

		Debug.Log (money.text);
		InvokeRepeating("updateSongs", 15f, 30f);
	}

	public void songCreated ()
	{
		double score = gameState.produceSong (textField.text);
		yourSong.text = "\"" + textField.text + "\"" + " is...";

		songForVideo.AddOptions(new List<string> { gameState.Songs[gameState.Songs.Count - 1].Title });

		sq.topic = topic.options [topic.value].text.ToString ();
		sq.style = style.options [style.value].text.ToString ();
		sq.tempo = tempo.options [tempo.value].text.ToString ();
		sq.featuring = featuring.options [featuring.value].text.ToString ();
		Debug.Log (sq.topic);

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
		if (gameState.Money > gameState.Microphone.Cost)
			gameState.Microphone.levelUp (gameState);
		else
			menuEn.openNotEnoughMoney ();
	}

	public void upgradeComputer ()
	{
		if (gameState.Money > gameState.Computer.Cost) 
			gameState.Computer.levelUp (gameState);
		else
			menuEn.openNotEnoughMoney ();
	}

	public void upgradeProducer ()
	{
		if (gameState.Money > gameState.Producer.Cost) 
			gameState.Producer.levelUp (gameState);
		else
			menuEn.openNotEnoughMoney ();
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
		stuff.text = gameState.Stuff.ToString () + " (g)";
		updatePrices ();
		playerLevel.text = "Lv. " + gameState.Level.ToString ();
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
			songList.text += "Song \""+ name +"\" has " + listens + " listens. " + song.Score + "/10\n";
		}
	}

	void updateSongs ()
	{
		gameState.updateSongs ();
		setUpSongList ();
		if (counting) {
			++ttd;
			if (ttd >= 10) {
				menuEn.openGameOver ();
			}
		}
		gameState.buyStuff ();
	}
}
