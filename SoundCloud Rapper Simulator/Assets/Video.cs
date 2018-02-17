using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video
{
    private Song song;

    public Song Song { get { return song;  } }

    public Video(Song song)
    {
        this.song = song;
    }


}
