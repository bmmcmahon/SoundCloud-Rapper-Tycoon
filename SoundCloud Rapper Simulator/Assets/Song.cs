using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Song 
{
	private string title;
	private double score;
	private int listeners;
	private double profit;
	private int updateLength;

	public string Title { get { return title; } }
	public double Score { get { return score; } set { score = value; } }
	public int Listeners { get { return listeners; } set { listeners = value; } }
	public double Profit { get { return profit; } set { profit = value; } }

	public Song(string title)
	{
		this.title = title;
		this.score = 0;
		this.listeners = 0;
		this.profit = 0;
		this.updateLength = new System.Random ().Next(10, 51); // Random number 10-50
	}

	public double updateStats(int followers)
	// Return the amount of money made in this cycle
	{
		int newListeners = (this.updateLength * (int) this.score * followers) / 100;
		double newProfit = newListeners / 50.0;

		this.listeners += newListeners;
		this.profit += newProfit;

		this.updateLength -= 1;

		return newProfit;
	}
}
