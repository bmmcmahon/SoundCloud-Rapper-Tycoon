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
	}
}
