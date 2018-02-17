using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	private GameState gameState;
	private UnityEngine.UI.InputField textField;
	private MenuEnabler menuEn;

	// Use this for initialization
	void Start () {
		gameState = new GameState ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
		menuEn = GetComponent<MenuEnabler> ();
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
		
	}
}
