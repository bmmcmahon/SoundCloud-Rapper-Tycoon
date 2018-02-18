using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video
{
    private Song song;
	private int views;

    public Song Song { get { return song;  } }
	public string Title { get { return song.Title; } }
	public int Views { get { return views; } }

    public Video(Song song)
    {
        this.song = song;
		this.views = 0;
    }


}
