using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState 
{
	private int followers;
	private int money;
	private int level;
	private List<Song> songs;

	private Equipment microphone;
	private Equipment computer;
	private Equipment producer;

	private UnityEngine.UI.InputField textField;

	public int Level { get { return level; } }
	public int Money { get { return money; } }
	public int Followers { get { return followers; } }

	public Equipment Microphone { get { return microphone; } }
	public Equipment Computer { get { return computer; } }
	public Equipment Producer { get { return producer; } }

	public GameState()
	{
		this.followers = 0;
		this.money = 100;
		this.level = 1;
		this.songs = new List<Song> ();
		textField = GameObject.Find("SongCreator").GetComponentInChildren<UnityEngine.UI.InputField>();
	}

	public void songCreated ()
	{
		produceSong (textField.text);
		textField.text = "";
		Debug.Log ("dfsA");
	}
		

	public double produceSong(string title)
	{
		var song = new Song (title);
		double score = getGameScore ();

		song.Score = score;
		updateFollowers (score);

		return score;
	}

	private void updateFollowers(double score)
	{
		int randomFactor = new System.Random().Next(1, 6);
		this.followers = randomFactor * (int) (score - 4);
	}

	private double getGameScore()
	{
		var random = new System.Random();
		int randomFactorOne = random.Next(1, 6);
		int randomFactorTwo = random.Next(1, 11);

		double score = (randomFactorOne * this.level) / 50 + randomFactorTwo;
		if (random.Next (1, 5) == 1) { score *= -1; } // 25% chance to negate the score

		return Math.Round(score, 1); // Return the score rounded to 1 decimal place
	}
}

