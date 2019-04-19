using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class Our_UI : MonoBehaviour {
    //////////////////////////////////////////////////////////////////////////// FIELDS //////////////////////////////////////////////////////////////////////
    public TMP_InputField newValue;
    public TMP_Dropdown newKey;
    public DisplayInit displayInit;

    public TMP_InputField lname;
    public TMP_InputField fname;
    public TMP_InputField phone;
    public TMP_InputField email;
    public TMP_InputField hair;
    public TMP_InputField eyes;
    public TMP_Text otherData;
    public Text action_Button_label;
    public Button action_Button;

    public FlickerLights flickerLights;
    public UI_Handler ui_handler;
    public GameObject yogaVideoObject;
    public GameObject yogaVideoObject2;
    public TrailRenderer trailR;
    public TrailRenderer trailL;


    private bool dataBreachAlreadyInitiated = false;

    public void initiateYogaExercise()
    {
        yogaVideoObject.SetActive(true);
        trailL.enabled = false;
        trailR.enabled = false;
    }

    public void initiateYogaExercise2()
    {
        trailL.enabled = false;
        trailR.enabled = false;
        yogaVideoObject.SetActive(false);
        yogaVideoObject2.SetActive(true);
    }

    public void initiateLightTrails()
    {
        trailL.enabled = true;
        trailR.enabled = true;
        trailR.Clear();
        trailL.Clear();
    }

    public void initiateDataBreach()
    {
        if (!dataBreachAlreadyInitiated)
        {
            ////////////////////////// ADD INPUT FIELDS TO DATABASE ///////
            if (!lname.text.Equals("") && !fname.text.Equals("")) {
                ui_handler.AddKeyValue("Name", (string)(fname.text + "_" + lname.text));
                ui_handler.AddKeyValue("FName", (string)(fname.text));
                ui_handler.AddKeyValue("LName", (string)(lname.text));
            }
            if (!phone.text.Equals("")) ui_handler.AddKeyValue("Phone", (string)(phone.text));
            if (!email.text.Equals("")) ui_handler.AddKeyValue("EMail", (string)(email.text));
            if (!hair.text.Equals("")) ui_handler.AddKeyValue("Hair", (string)(hair.text));
            if (!eyes.text.Equals("")) ui_handler.AddKeyValue("Eyes", (string)(eyes.text));

            ////////////////////////// SET WALLS ////////
            //ui_handler.setLeftWall();
            ui_handler.setRightWall();
            ui_handler.setID();

            //disable trails
            trailL.enabled = false;
            trailR.enabled = false;

            //disable yoga animations
            yogaVideoObject.SetActive(false);
            yogaVideoObject2.SetActive(false);

            //Special FX
            flickerLights.lockDownProcedures();

            action_Button_label.text = "INITIATING DATA BREACH, WAIT UNTIL COMPLETE";
            action_Button.interactable = false;

            //switch EventSystem model back to VR
            ui_handler.switchESbackToVR();
            //disable our UI
            displayInit.setDoneWithOurUI();
        }
        else { endDataBreach();  }

        dataBreachAlreadyInitiated = true;
    }

    public void reenableButton () {
        action_Button_label.text = "End Data Breach (Wait and give user time to read stuff first)";
        action_Button.interactable = true;
    }

    public void endDataBreach(){
        flickerLights.revertToNormal();
        action_Button_label.text = "Data Breach Complete";
        action_Button.interactable = false;
    }

    public void addNewKeyValuePair()
    {
        //add to database
        ui_handler.AddKeyValue(newKey.options[newKey.value].text, newValue.text);
        //display on Screen
        otherData.text += newKey.options[newKey.value].text + ": " + newValue.text + "\n";
        //reset input field and dropdown
        newKey.value = 0;
        newValue.text = "";
    }
}
