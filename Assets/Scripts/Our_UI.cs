using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class Our_UI : MonoBehaviour {
    public FlickerLights flickerLights;
    public TMP_InputField internetData;
    public TMP_InputField observedData;
    public TMP_InputField lname;
    public TMP_InputField fname;
    public TMP_InputField phone;
    public TMP_InputField email;
    public TMP_InputField hair;
    public TMP_InputField eyes;
    public UI_Handler ui_handler;
    public Text action_Button_label;
    public Button action_Button;

    public GameObject yogaVideoObject;

    private bool dataBreachAlreadyInitiated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void initiateYogaExercise()
    {
        yogaVideoObject.SetActive(true);
    }

    public void initiateDataBreach()
    {
        if (!dataBreachAlreadyInitiated)
        {
            //INITIATE DATA BREACH< SEND DATA TO UI_HANDLER

            //front wall
            string namePhoneEmail = "Name: " + lname.text + ", " + fname.text + "\n" + "Phone: " + phone.text + "\n" + "E-Mail: " + email.text + "\n";
            ui_handler.set_name_phone_email_and_ui_data(namePhoneEmail);

            //top wall
            string formattedname = "" + lname.text + ", \n" + fname.text;
            ui_handler.set_ID_Card(eyes.text, hair.text, formattedname);

            //left wall
            ui_handler.set_internet_and_observed_data("" + internetData.text +"\n"+ observedData.text);

            //right wall
            //bought information

           
            ui_handler.setSoldWall(email.text);

            //back wall
            //running code

            //floor?




            flickerLights.lockDownProcedures();

            action_Button_label.text = "INITIATING DATA BREACH, WAIT UNTIL COMPLETE";
            action_Button.interactable = false;
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
}
