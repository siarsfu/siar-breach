using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FlickerLights : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    public GameObject roomObject;
    public GameObject[] houseObjects;
    public Renderer[] houseMats;
    public Light mainSceneLight;
    public Material skyboxMat;
    public GameObject[] canvases;

    public GameObject videoPlayerObject;
    public VideoPlayer videoPlayer;

    public Animator animator;

    public UI_Handler ui_handler;

    //transition-related
    public VideoPlayer beachVideo;
    public AudioSource videoSound;
    public AudioSource alarmSound;
    public Animator alarmAnimation;
    public GlitchEffect glitchEffect;
    public VideoPlayer noiseScreens;
    public Animator tvNoiseControlTransparency;
    public Renderer video360Renderer;
    public Renderer roomRenderer;
    public GameObject bootUpScreen;
    public AudioSource breakerSwitch;
    public GameObject robotObject;
    public GameObject yogaVideoObject;

    public Material shellSkybox;
    public Material breachSkybox;

    public GameObject meadowAudio;
    public GameObject adsScreens;

    public AudioSource breachAmbient;

    private Material roomMaterial;
    private Color endColor;
    private bool onMeadow = true;


    //////////////////////////////////////////////////////////////////////////// START ///////////////////////////////////////////////////////////////////////
    void Start()
    {
        houseObjects = GameObject.FindGameObjectsWithTag("room");
        int size = houseObjects.Length;
        houseMats = new Renderer[size];

        Debug.Log(size);

        for (int i = 0; i < houseObjects.Length; i++){
            Debug.Log(i);
            houseMats[i] = houseObjects[i].GetComponent<Renderer>();
        }

        endColor = Color.black;
        //endColor.a = 130f / 256;
        skyboxMat = RenderSettings.skybox;

        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(false);
        }

        videoPlayerObject.SetActive(false);

    }

    //////////////////////////////////////////////////////////////////////////// SHELL -> BREACH
    public void lockDownProcedures()
    {
        //stop playing video audio
        //videoSound.mute = true;
        beachVideo.SetDirectAudioMute(0, true);

        //animator.enabled = true;
        alarmSound.Play();

        //then mess with the head even more

        //start animating the alarm
        alarmAnimation.enabled = true;

        //wait 10 seconds to turn all screens onto noise
        StartCoroutine(turnTVNoise());

        //StartCoroutine(dimmingProcedure());
        //StartCoroutine(putUpAllText());
    }

    IEnumerator turnTVNoise(){

        //before the noise, start glitching
        glitchEffect.intensity = 0.5f;
        glitchEffect.flipIntensity = 0.5f;
        glitchEffect.colorIntensity = 0.5f;
        glitchEffect.enabled = true;

        yield return new WaitForSeconds(10f);

        //start tvnoise
        noiseScreens.Play();

        //increase glitching
        glitchEffect.intensity = 0.75f;
        glitchEffect.flipIntensity = 0.75f;
        glitchEffect.colorIntensity = 0.75f;

        yield return new WaitForSeconds(1f);

        //remove transparency so that noise occupies all space
        tvNoiseControlTransparency.enabled = true;

        yield return new WaitForSeconds(4f);

        //disable the video renderer
        video360Renderer.enabled = false;

        //ztay in that state for a second
        yield return new WaitForSeconds(1f);

        //don't show the robot
        robotObject.SetActive(false);

        //stop showing the yoga video
        yogaVideoObject.SetActive(false);

        //ROBERT: switch the skybox 
        RenderSettings.skybox = breachSkybox;
        meadowAudio.SetActive(false);

        //slowly get back transparency (to 0)
        tvNoiseControlTransparency.Play("tv_noise_restore");

        //stop glitching
        glitchEffect.enabled = false;

        yield return new WaitForSeconds(4f);

        //stop displaying the room and its borders
        //roomRenderer.enabled = false;

        //remove tvnoise
        noiseScreens.Stop();

        yield return new WaitForSeconds(6f);

        //access granted just sounded

        //boot up screen
        bootUpScreen.GetComponent<Renderer>().enabled = true;
        bootUpScreen.GetComponent<VideoPlayer>().Play();

        yield return new WaitForSeconds(7f);
        bootUpScreen.GetComponent<Renderer>().enabled = false;

        

        //restore transparency back
        StartCoroutine(nextStage());
        breachAmbient.Play();

        //now is the time to slowly start switching on skybox
        breakerSwitch.Play();
        Material skybox = RenderSettings.skybox;
        while (true){
            float currentExposure = skybox.GetFloat("_Exposure");
            float updatedExposure = Mathf.Lerp(currentExposure, 1f, Time.deltaTime*0.5f);
            skybox.SetFloat("_Exposure", updatedExposure);
            yield return null;
        }

    }

    public void tvStatic()
    {
        noiseScreens.Play();
    }

    IEnumerator nextStage(){
        yield return new WaitForSeconds(5f);
        tvNoiseControlTransparency.Play("tv_noise_from_0_to_45");

        yield return new WaitForSeconds(4f);
        ui_handler.turnOnDataBreachScreens();

        yield return null;
    }

    IEnumerator putUpAllText(){

        yield return new WaitForSeconds(4f);

        //for (int i = 0; i < canvases.Length; i++){
        //    canvases[i].SetActive(true);
        //}

        //videoPlayerObject.SetActive(true);
        //videoPlayer.Play();

        ui_handler.turnOnDataBreachScreens();


    }

    IEnumerator dimmingProcedure(){

        while (true){

            for (int i = 0; i < houseMats.Length; i++){
                houseMats[i].material.color = Color.Lerp(houseMats[i].material.color, endColor, Time.deltaTime);
            }

            //float currentExposure = skyboxMat.GetFloat("_Exposure");
            //float updatedExposure = Mathf.Lerp(currentExposure, 0, Time.deltaTime * 2f);
            //skyboxMat.SetFloat("_Exposure", updatedExposure);
            yield return null;
        }

        yield return null;
    }

    //////////////////////////////////////////////////////////////////////////// BREACH -> SHELL
    public void stopBreachAmbient() {
        if (breachAmbient.isPlaying) breachAmbient.Stop();
    }

    public void revertToNormal()
    {
        //start tvnoise
        noiseScreens.Play();

        StartCoroutine(revertProcess());
        ui_handler.turnOffDataBreachScreens();
    }

    IEnumerator revertProcess()
    {
        yield return new WaitForSeconds(1f);

        tvNoiseControlTransparency.Play("tv_noise");

        yield return new WaitForSeconds(4f);

        video360Renderer.enabled = true;

        //ROBERT: switch the skybox
        RenderSettings.skybox = shellSkybox;
        if (onMeadow) meadowAudio.SetActive(true);
        breachAmbient.Stop();

        yield return new WaitForSeconds(1f);

        //robotObject.SetActive(true);

        tvNoiseControlTransparency.Play("tv_noise_revert");
        beachVideo.SetDirectAudioMute(0, false);
        alarmAnimation.enabled = false;

        //Destroy(alarmAnimation);
        video360Renderer.material.color = Color.white;

        yield return new WaitForSeconds(4f);

        noiseScreens.Stop();
        adsScreens.SetActive(true);

        yield return null;
    }

    //////////////////////////////////////////////////////////////////////////// OTHER
    public void setMeadow(bool input)
    {
        onMeadow = input;
    }
}
