using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {

    public Toggle sleepToggle;
    public Toggle alcToggle;
    public Toggle canToggle;
    public Toggle tobToggle;
    public Toggle othToggle;
    public UI_Handler ui_handler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void submitLightSleep() {
        if (sleepToggle.isOn)
        {
            ui_handler.AddKeyValue("Is a light sleeper: ", "Yes"); 
            ui_handler.showNextPanel();
        }
        else
        {
            ui_handler.AddKeyValue("Is a light sleeper: ", "No");
            ui_handler.showNextPanel();
        }
    }

    public void submitDrugs()
    {
        ui_handler.AddKeyValue("Consumes: Alcohol", convertBoolToString(alcToggle.isOn));
        ui_handler.AddKeyValue("Consumes: Cannabis", convertBoolToString(canToggle.isOn));
        ui_handler.AddKeyValue("Consumes: Tobacco", convertBoolToString(tobToggle.isOn));
        ui_handler.AddKeyValue("Consumes: Other Drugs", convertBoolToString(othToggle.isOn));
        ui_handler.showNextPanel();
    }

    private string convertBoolToString(bool input) { if (input) return "true"; else return "false"; }
}
