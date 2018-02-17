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
	private MenuEnabler menuEn;

	// Use this for initialization
	void Start () {
		gameState = new GameState ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
		menuEn = GetComponent<MenuEnabler> ();
		money = GameObject.Find ("/Stats/Panel/Money").GetComponent<Text> ();
		stuff = GameObject.Find ("/Stats/Panel/Stuff").GetComponent<Text> ();
		followers = GameObject.Find ("/Stats/Panel/Followers").GetComponent<Text> ();
		Debug.Log (money.text);
	}

	public void songCreated ()
	{
		gameState.produceSong (textField.text);
		textField.text = "";
		Debug.Log (gameState.Followers);
		menuEn.closeCreators ();
	}
	
	// Update is called once per frame
	void Update () {
		money.text = gameState.Money.ToString ();
		followers.text = gameState.Followers.ToString ();
	}
}
