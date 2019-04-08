using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour {
    //////////////////////////////////////////////////////////////////////////// FIELDS //////////////////////////////////////////////////////////////////////
    public TMP_Text totalTime;
    public TMP_Text shellTime;
    public TMP_Text breachTime;
    public TMP_Text abreachTime;

    private float totalT, breachStart, abreachStart;


    ////////////////////////////////////////////////////////////////////////////// UPDATE ////////////////////////////////////////////////////
	void Update () {
        totalT = Time.fixedTime;
        totalTime.text = totalT.ToString();
        if (breachStart == 0) shellTime.text = totalT.ToString();
        if (breachStart != 0 && abreachStart == 0) breachTime.text = (System.Math.Round(totalT - breachStart, 2)).ToString();
        if (abreachStart != 0) abreachTime.text = (System.Math.Round(totalT - abreachStart, 2)).ToString();
	}

    public void startBreach() {
        breachStart = totalT;
    }

    public void startABreach() {
        abreachStart = totalT;
    }
}
