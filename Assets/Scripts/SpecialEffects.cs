using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpecialEffects : MonoBehaviour {
    //////////////////////////////////////////////////////////////////////////// FIELDS //////////////////////////////////////////////////////////////////////
    public Animator staticAnimation;
    public VideoPlayer staticVideo;
    public Renderer staticRenderer;
    public GlitchEffect glitchEffect;

    public Material staticMaterial;
    public Color initialColor;
    public Color finalColor;

    public Our_UI our_UI;

    ////////////////////////////////////////////////////////////////////////////// START ////////////////////////////////////////////////////
	void Start () {
        staticMaterial = staticRenderer.material;
        initialColor = staticMaterial.color;
        finalColor = initialColor;
        finalColor.a = 0.7f;
	}

    private void doTvStatic()
    {
        //staticAnimation.enabled = true;
        staticVideo.Play();
        glitchEffect.enabled = true;
        
        //staticMaterial.color = finalColor;

        StartCoroutine(turnStaticOff());
    }

    IEnumerator turnStaticOff()
    {
        yield return new WaitForSeconds(1f);

        //staticAnimation.enabled = false;
        staticVideo.Stop();
        glitchEffect.enabled = false;
        //staticMaterial.color = initialColor;
       
    }
}
