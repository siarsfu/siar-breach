using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class disbaleVidAudio : MonoBehaviour {

    public VideoPlayer vp;

	// Use this for initialization
	void Awake () {
        vp.EnableAudioTrack(0, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
