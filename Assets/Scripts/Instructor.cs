using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour {

    public AudioSource s1_beach;
    public AudioSource s1_meadow;
    public AudioSource s2;
    public AudioSource s3;
    public AudioSource s4;
    public AudioSource s5_beach;
    public AudioSource s5_meadow;
    public AudioSource s6;
    public AudioSource s7;
    public AudioSource s8;
    public AudioSource s9;
    public AudioSource s10;
    public AudioSource s11_beach;
    public AudioSource s11_meadow;
    public AudioSource s12;
    public Our_UI our_ui;
    public bool onBeach = false;

    private int startedAudio = 0;
    private int doneAudio = 0;

    void Update()
    {
        //use to mute audio clips
        if (startedAudio == 1 && doneAudio == 0 && !s1_beach.isPlaying && !s1_meadow.isPlaying) { 
            doneAudio++; 
            StartCoroutine(s2Routine());
            s1_beach.mute = true;
            s1_meadow.mute = true;
        }
        if (startedAudio == 2 && doneAudio == 1 && !s2.isPlaying) { 
            doneAudio++;
            StartCoroutine(s3Routine());
            s2.mute = true;
        }
        if (startedAudio == 3 && doneAudio == 2 && !s3.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s4Routine());
            s3.mute = true;
        }
        if (startedAudio == 4 && doneAudio == 3 && !s4.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s5Routine());
            s4.mute = true;
        }
        if (startedAudio == 5 && doneAudio == 4 && !s5_beach.isPlaying && !s5_meadow.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s6Routine());
            s5_beach.mute = true;
            s5_meadow.mute = true;
        }
        if (startedAudio == 6 && doneAudio == 5 && !s6.isPlaying)
        {
            doneAudio++;
            startedAudio++; //skip, audio quality is too bad
            //StartCoroutine(s7Routine());
            s6.mute = true;
        }
        if (startedAudio == 7 && doneAudio == 6 && !s7.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s8Routine());
            s7.mute = true;
        }
        if (startedAudio == 8 && doneAudio == 7 && !s8.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s9Routine());
            s8.mute = true;
        }
        if (startedAudio == 9 && doneAudio == 8 && !s9.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s10Routine());
            s9.mute = true;
        }
        if (startedAudio == 10 && doneAudio == 9 && !s10.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s11Routine());
            s10.mute = true;
        }
        if (startedAudio == 11 && doneAudio == 10 && !s11_beach.isPlaying && !s11_meadow.isPlaying)
        {
            doneAudio++;
            StartCoroutine(s12Routine());
            s11_beach.mute = true;
            s11_meadow.mute = true;
        }
        if (startedAudio == 12 && doneAudio == 11 && !s12.isPlaying)
        {
            doneAudio++;
            s12.mute = true;
            StartCoroutine(finalRoutine());
        }
    }


    

    IEnumerator s1Routine()
    {
        yield return new WaitForSeconds(1);
        if (onBeach)
        {
            s1_beach.Play();
        }
        else
        {
            s1_meadow.Play();
        }
        startedAudio++;
    }

    IEnumerator s2Routine()
    {
        yield return new WaitForSeconds(3);
        our_ui.initiateLightTrails();
        s2.Play();
        startedAudio++;
    }

    IEnumerator s3Routine()
    {
        yield return new WaitForSeconds(25);
        our_ui.initiateYogaExercise();
        s3.Play();
        startedAudio++;
    }

    IEnumerator s4Routine()
    {
        yield return new WaitForSeconds(4);
        s4.Play();
        startedAudio++;
    }

    IEnumerator s5Routine()
    {
        yield return new WaitForSeconds(3);
        if (onBeach)
        {
            s5_beach.Play();
        }
        else
        {
            s5_meadow.Play();
        }
        startedAudio++;
    }

    IEnumerator s6Routine()
    {
        yield return new WaitForSeconds(3);
        s6.Play();
        startedAudio++;
    }

    IEnumerator s7Routine()
    {
        yield return new WaitForSeconds(3);
        s7.Play();
        startedAudio++;
    }

    IEnumerator s8Routine()
    {
        yield return new WaitForSeconds(3);
        our_ui.initiateYogaExercise2();
        s8.Play();
        startedAudio++;
    }

    IEnumerator s9Routine()
    {
        yield return new WaitForSeconds(3);
        s9.Play();
        startedAudio++;
    }

    IEnumerator s10Routine()
    {
        yield return new WaitForSeconds(2);
        s10.Play();
        startedAudio++;
    }

    IEnumerator s11Routine()
    {
        yield return new WaitForSeconds(3);
        if (onBeach)
        {
            s11_beach.Play();
        }
        else
        {
            s11_meadow.Play();
        }
        startedAudio++;
    }

    IEnumerator s12Routine()
    {
        yield return new WaitForSeconds(2);
        s12.Play();
        startedAudio++;
    }

    IEnumerator finalRoutine()
    {
        yield return new WaitForSeconds(3);
        our_ui.initiateDataBreach();
    }




    public void startYogaSequence()
    {
        StartCoroutine(s1Routine());
    }
    public void setEnvironment(bool isItBeach)
    {
        onBeach = isItBeach;
    }
}
