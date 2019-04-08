using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour {
    //////////////////////////////////////////////////////////////////////////// FIELDS //////////////////////////////////////////////////////////////////////
    /* Script found at: https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html */
    public Typewriter nextScreen;
    public Typewriter nextScreen2;
    public Typewriter nextScreen3;

    public ErrorMsg errorMsg;

    public TMP_Text textObject;
    public bool isFront = false; 
    string origText = "";

    private float delay = .01f;
    private float reverseDelay = .005f;

    bool activatingPrompt = false;
    bool doneAnimatingText = false;

    public GameObject deletePanel;

    public Auction auction;

    public AudioSource text2speech1;
    public AudioSource text2speech2;
    public AudioSource typingRL;
    public AudioSource typingRR;
    public AudioSource typingLL;
    public AudioSource typingLR;
    public AudioSource typingB;

    
    public bool isLL;
    public bool isLR;
    public bool isRL;
    public bool isRR;
    public bool isB;

    public UI_Handler ui_handler;

    bool firstRun = true;

    public GameObject idPic;

    ////////////////////////////////////////////////////////////////////// AWAKE /////////////////////////////////////////////////////////////
    void Awake()
    {
        origText = textObject.text;
        textObject.text = "";
        if (isFront) delay = .037f;
    }

    ////////////////////////////////////////////////////////////////////// UPDATE /////////////////////////////////////////////////////////////
    void Update()
    {
        //activate delete prompt when Tab is pressed
        if (Input.GetKeyDown(KeyCode.Tab) && isFront && doneAnimatingText) { activatePrompt(); ui_handler.activatePointer();  }
    }

    /////////////////////////////////////////////////////////////////// ANIMATETEXT 
    IEnumerator AnimateTextRoutine()
    {
        for (int i = 0; i < (origText.Length + 1); i++)
        {
            textObject.text = origText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        //animate next Screen (if there is one), once this Screen is done animating (if not activating prompt)
        if (nextScreen != null && !activatingPrompt) nextScreen.animateText();
        if (nextScreen2 != null && !activatingPrompt) nextScreen2.animateText();
        if (nextScreen3 != null && !activatingPrompt) nextScreen3.animateText();
        //if activating delete Prompt: show delete Panel
        if (activatingPrompt)
        {
            activatingPrompt = false;
            deletePanel.SetActive(true);
        }
        origText = textObject.text;
        doneAnimatingText = true;

        if (auction != null) auction.startAuction();

        //stop audio
        if (isLL && typingLL.isPlaying) typingLL.Stop();
        if (isRL && typingRL.isPlaying) typingRL.Stop();
        if (isLR && typingLR.isPlaying) typingLR.Stop();
        if (isRR && typingRR.isPlaying) typingRR.Stop();
        if (isB && typingB.isPlaying) typingB.Stop();

        if (isFront && firstRun) idPic.SetActive(true);
        firstRun = false;
    }

    public void animateText()
    {
        StartCoroutine(AnimateTextRoutine());
        //play audio
        if (isFront && !activatingPrompt && !text2speech1.isPlaying) text2speech1.Play();
        if (isFront && activatingPrompt && !text2speech2.isPlaying) text2speech2.Play();
        if (isLL && !typingLL.isPlaying) typingLL.Play();
        if (isRL && !typingRL.isPlaying) typingRL.Play();
        if (isLR && !typingLR.isPlaying) typingLR.Play();
        if (isRR && !typingRR.isPlaying) typingRR.Play();
        if (isB && !typingB.isPlaying) typingB.Play();
    }

    ///////////////////////////////////////////////////////////////// REVERSEANIMATETEXT 
    IEnumerator ReverseAnimateTextRoutine() {
        for (int i = origText.Length; i > 0; i--)
        {
            textObject.text = origText.Substring(0, i);
            yield return new WaitForSeconds(reverseDelay);
        }
        textObject.text = "";
        //display Error Message (No Data Found) if errorMsg has been assigned (only the case on front) and not activating Prompt
        if (errorMsg != null && !activatingPrompt) errorMsg.startTimer();
        //prepare to show prompt to delete text
        if (activatingPrompt) {
            origText = "You can now take <color=#b4353c>control</color> of your information. I give you the <color=#b4353c>choice</color>...";
            animateText();
        }

        //stop audio
        if (isLL && typingLL.isPlaying) typingLL.Stop();
        if (isRL && typingRL.isPlaying) typingRL.Stop();
        if (isLR && typingLR.isPlaying) typingLR.Stop();
        if (isRR && typingRR.isPlaying) typingRR.Stop();
        if (isB && typingB.isPlaying) typingB.Stop();
    }

    public void reverseAnimateText() {
        StartCoroutine(ReverseAnimateTextRoutine());

        //play audio
        if (isLL && !typingLL.isPlaying) typingLL.Play();
        if (isRL && !typingRL.isPlaying) typingRL.Play();
        if (isLR && !typingLR.isPlaying) typingLR.Play();
        if (isRR && !typingRR.isPlaying) typingRR.Play();
        if (isB && !typingB.isPlaying) typingB.Play();
    }

    ///////////////////////////////////////////////////////////////// ACTIVATEPROMPT 
    // NOTE: This is launched from the KEYBOARD, it deletes the front message and replaces it with the prompt to delete data or keep it
    void activatePrompt()
    {
        activatingPrompt = true;
        reverseAnimateText();
    }

}
