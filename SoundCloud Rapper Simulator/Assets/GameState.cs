using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState 
{
	private int followers;
	private double money;
	private int level;
	private List<Song> songs;
	private List<Video> videos;
	private double stuff;

	private Equipment microphone;
	private Equipment computer;
	private Equipment producer;

	public int Level { get { return level; } set { level = value; } }
	public double Money { get { return Math.Round(money, 2); } set { money = value; } }
	public int Followers { get { return followers; } }
	public double Stuff { get { return Math.Round(stuff, 2); } }

	public Equipment Microphone { get { return microphone; } }
	public Equipment Computer { get { return computer; } }
	public Equipment Producer { get { return producer; } }

	public List<Song> Songs { get { return songs; } }

	public GameState()
	{
		this.followers = 3;
		this.money = 30;
		this.level = 1;
		this.songs = new List<Song> ();
		this.videos = new List<Video> ();
		this.stuff = 1;

		microphone = new Equipment ();
		computer = new Equipment ();
		producer = new Equipment ();
	}
		
	public double produceSong(string title)
	{
		string debug = "Song Created. Score: {0} Profit: {1} Listeners: {2} UpdateLength: {3}";

		this.money -= (10.0 + 0.10 * this.money) * this.level; // Initial cost to make song
		var song = new Song (title);
		double score = getGameScore ();
		int listeners = initialListeners (score);
		double profit = initalMoney (listeners);

		song.Listeners = listeners;
		song.Score = score;
		song.Profit = profit;

		song.UpdateLength = new System.Random ().Next (1, 6) * ((int)score/2);

		Debug.Log (String.Format (debug, score, Math.Round(profit, 2), listeners, song.UpdateLength));

		updateFollowers (score);

		this.songs.Add (song);

		return score;
	}

	public double produceVideo(Song song)
	{
		this.money -= (10.0 + 0.10 * this.money) * this.level * 2; // Double the cost of a song
		var video = new Video (song);

		double score = getGameScore ();
		int viewers = initialListeners (score);
		double profit = initalMoney (viewers);

		this.videos.Add (video);

		return score;
	}

	private void updateFollowers(double score)
	{
		int randomFactor = new System.Random().Next(1, 6);
		int followerChange = randomFactor * (int) (score - 4);
		if (this.followers + followerChange >= 0) { this.followers += followerChange; }
	}

	private double getGameScore()
	{
		var random = new System.Random();
		int randomFactorOne = random.Next(1, 6);
		int randomFactorTwo = random.Next(1, 11);

		if (random.Next (1, 5) == 1) { randomFactorOne *= -1; } // 25% chance to negate the first part

		double score = (randomFactorOne * this.level) / 50 + randomFactorTwo;

		if (score > 10) { return 10.00; }

		return Math.Round(score, 1); // Return the score rounded to 1 decimal place
	}

	private int initialListeners(double score)
	{
		int randomFactor = new System.Random().Next(2, 7);
		int listeners = randomFactor * (((int)score) / 2) * followers;

		return listeners;
	}

	private double initalMoney (int listeners)
	{	
		double money = listeners / 15.0;
		this.money += money;

		return money;
	}

	public void updateSongs()
	{
		for(int i = 0; i < this.songs.Count; ++i)
		{ 
			double newProfit = this.songs [i].updateStats (this.followers);
			this.money += newProfit;
		}
	}

	public double buyStuff()
	{
		int costOfStuff = 10;
		double moneyToSpend = 0.1 * this.money;
		double newStuff = moneyToSpend / costOfStuff;

		this.stuff += newStuff;
		this.money -= moneyToSpend;

		return moneyToSpend; // return how much money spent on stuff
	}

	public bool getShot()
	{
		var random = new System.Random();
		int chance = random.Next (1, 16); // 1/15 chance to get shot
		int chance2 = random.Next (1, 16);

		return chance == chance2;
	}
}