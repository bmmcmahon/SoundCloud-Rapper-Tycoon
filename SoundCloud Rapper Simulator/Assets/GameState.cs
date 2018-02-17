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

	public int Level { get { return level; } }
	public int Money { get { return money; } }
	public int Followers { get { return followers; } }

	public GameState()
	{
		this.followers = 0;
		this.money = 100;
		this.level = 1;
		this.songs = new List<Song> ();
	}

	public double produceSong(string title)
	// creates a new song
	{
		var song = new Song (title);
		double score = getGameScore ();
		song.Score = score;
		return score;
	}

	private void updateFollowers(int score)
	{
		int randomFactor = new System.Random().Next(1, 6);
		this.followers = randomFactor * (score - 4);
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

