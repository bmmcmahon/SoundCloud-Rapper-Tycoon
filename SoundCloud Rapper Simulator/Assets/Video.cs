using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video
{
    private Song song;
	private int views;
	private int updateLength;
	private double profit;
	private double score;

    public Song Song { get { return song;  } }
	public string Title { get { return song.Title; } }
	public int Views { get { return views; } set { views = value; } } 
	public int UpdateLength { get { return updateLength; } set { updateLength = value; } }
	public double Profit { get { return profit; } set { profit = value; } }
	public double Score { get { return score; } set { score = value; } }

    public Video(Song song)
    {
        this.song = song;
		this.views = 0;
		this.updateLength = 0;
		this.profit = 0;
		this.score = 0;
    }

	public double updateStats(int followers)
	{
		if (this.updateLength <= 0) { return 0.0; }

		int newViews = (this.updateLength * (int)this.score * followers) / 30;
		double newProfit = newViews / 15.0;

		this.views += newViews;
		this.profit += newProfit;

		this.updateLength -= 1;

		return newProfit;
	}


}
