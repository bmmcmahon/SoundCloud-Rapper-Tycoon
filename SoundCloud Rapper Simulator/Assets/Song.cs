using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Song 
{
	private string title;
	private double score;
	private int listeners;

	public string Title { get { return title; } }
	public double Score { get { return score; } set { score = value; } }
	public int Listeners { get { return listeners; } set { listeners = value; } }

	public Song(string title)
	{
		this.title = title;
		this.score = 0;
		this.listeners = 0;
	}
}
