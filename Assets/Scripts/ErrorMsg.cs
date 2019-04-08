using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMsg : MonoBehaviour {
    //Class is very similar to Typewriter class. It is responsible for the Error Message shown when user presses "Delete [Data]".
    /* Script found at: https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html */
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    public TMP_Text textObject;
    public AudioSource typingF;
    public AudioSource dialUp;
    public AudioSource errorAudio;
    public FlickerLights flickerLights;

    string origText = "";
    float timeLeft = 8;
    bool timerStarted = false;
    bool startedTyping = false;

    //////////////////////////////////////////////////////////////////////////// UPDATE ///////////////////////////////////////////////////////////////////////
	void Update () {
        if (timerStarted && !startedTyping)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //show Error Message after a small timer has expired.
                animateText();
                startedTyping = true;
            }
        }
	}

    IEnumerator AnimateTextRoutine()
    {
        for (int i = 0; i < (origText.Length + 1); i++)
        {
            textObject.text = origText.Substring(0, i);
            yield return new WaitForSeconds(.05f);
        }
        typingF.Stop();
    }

    //play SFX, activate VFX, start Typewriter Coroutine and set the new Text (to Error Message)
    public void animateText()
    {
        if (dialUp.isPlaying) dialUp.Stop(); dialUp.mute = true;
        flickerLights.tvStatic();
        errorAudio.Play();
        textObject.text = "";
        origText = "<color=#b4353c>ERROR: NO DATA FOUND</color>";
        StartCoroutine(AnimateTextRoutine());
        if (!typingF.isPlaying) typingF.Play();
    }

    public void startTimer() {
        timerStarted = true;
    }
}
