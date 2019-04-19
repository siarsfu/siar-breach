using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MultiBtn : MonoBehaviour {
    //UI CLASS: For Panels with Multiple Choice Buttons as Input type. Handles user input and submission of data to UI Handler.
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    [System.Serializable]
     public enum AnswerSets
     {
        Gender,
        Activity,
        Environment
     }
    public UI_Handler ui_handler;
    public AnswerSets question;
    public GameObject BeachSphere;
    public GameObject MeadowSound;
    public GameObject BeachSound;
    public GameObject BeachSound2;
    public Button meadowButton;
    public Button beachButton;
    public FlickerLights flickerLights;
    public Instructor instructor;
    private bool onBeach;

    public void submitMultiBtn(string value) {
        if (question == AnswerSets.Gender) 
        {
            ui_handler.AddKeyValue("Gender", value); ui_handler.showNextPanel();
        }
        else if (question == AnswerSets.Activity)
        {
            ui_handler.AddKeyValue("Activity_Level", value); ui_handler.showNextPanel();
        }
    }

    public void setEnvironment(string value)
    {
        if (value.Equals("Beach"))
        {
            ColorBlock orangeBlock = beachButton.colors;
            orangeBlock.normalColor = new Color(0.87f, 0.32f, 0f, 1f);
            orangeBlock.highlightedColor = new Color(0.87f, 0.32f, 0f, 1f);
            orangeBlock.pressedColor = new Color(0.87f, 0.32f, 0f, 1f);
            beachButton.colors = orangeBlock;

            ColorBlock blueBlock = meadowButton.colors;
            blueBlock.normalColor = new Color(0.35f, 0.51f, 0.77f, 1f);
            blueBlock.highlightedColor = new Color(0.46f, 0.59f, 0.81f, 1f);
            blueBlock.pressedColor = new Color(0.87f, 0.32f, 0f, 1f);
            meadowButton.colors = blueBlock;

            BeachSphere.SetActive(true);
            MeadowSound.SetActive(false);
            BeachSound.SetActive(true);
            BeachSound2.SetActive(true);
            flickerLights.setMeadow(false);
            onBeach = true;
        }
        else
        {
            ColorBlock orangeBlock = meadowButton.colors;
            orangeBlock.normalColor = new Color(0.87f, 0.32f, 0f, 1f);
            orangeBlock.highlightedColor = new Color(0.87f, 0.32f, 0f, 1f);
            orangeBlock.pressedColor = new Color(0.87f, 0.32f, 0f, 1f);
            meadowButton.colors = orangeBlock;

            ColorBlock blueBlock = beachButton.colors;
            blueBlock.normalColor = new Color(0.35f, 0.51f, 0.77f, 1f);
            blueBlock.highlightedColor = new Color(0.46f, 0.59f, 0.81f, 1f);
            blueBlock.pressedColor = new Color(0.87f, 0.32f, 0f, 1f);
            beachButton.colors = blueBlock;

            BeachSphere.SetActive(false);
            MeadowSound.SetActive(true);
            BeachSound.SetActive(false);
            BeachSound2.SetActive(false);
            flickerLights.setMeadow(true);
            onBeach = false;
        }
    }

    public void submitEnvironment()
    {
        ui_handler.showNextPanel();
        instructor.setEnvironment(onBeach);
    }
}
