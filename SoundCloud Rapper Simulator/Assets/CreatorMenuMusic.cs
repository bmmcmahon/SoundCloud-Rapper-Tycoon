using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorMenuMusic : MonoBehaviour {

	private AudioSource creatorMusic;

	// Use this for initialization
	void Start () {
		creatorMusic = GameObject.Find ("CreatorMusic").GetComponent<AudioSource> ();
		creatorMusic.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
