using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song 
{
	private string title;
	private double score;

	public string Title { get { return title; } }
	public double Score { get { return score; } set { score = value; } }

	public Song(string title)
	{
		this.title = title;
		this.score = 0;
	}
}
