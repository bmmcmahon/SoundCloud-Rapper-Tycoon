﻿using System.Collections;
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
	public int UpdateLength { get { return updateLength; } set { updateLength = value; } }

	public Song(string title)
	{
		this.title = title;
		this.score = 0;
		this.listeners = 0;
		this.profit = 0;
		this.updateLength = 0;
	}

	public double updateStats(int followers)
	// Return the amount of money made in this cycle
	{
		if (this.updateLength <= 0) { return 0.0; }

		int newListeners = (this.updateLength * (int)this.score * followers) / 30;
		double newProfit = newListeners / 15.0;

		this.listeners += newListeners;
		this.profit += newProfit;

		this.updateLength -= 1;

		Debug.Log(String.Format("{0}. New Listeners: {1} New Profit: {2} UpdateLength: {3}", this.title, newListeners, Math.Round(newProfit,2), this.updateLength));

		return newProfit;
	}
}
