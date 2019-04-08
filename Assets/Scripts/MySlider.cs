using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MySlider : MonoBehaviour
{
    //UI CLASS: For Panels with Sliders as Input type. Handles user input and submission of data to UI Handler.
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    string value = "";
    public Slider slider;
    public UI_Handler ui_handler;
    public TMP_Text outText;
    public Button submitBtn;

    //public void submitCalories() { updateValue(); ui_handler.AddKeyValue("Calories consumed per day", value + "kcal"); ui_handler.showNextPanel(); }
    public void submitDaysHome() { updateValue(); ui_handler.AddKeyValue("Days_working_out_home", value + " days"); ui_handler.showNextPanel(); }
    public void submitDaysGym() { updateValue(); ui_handler.AddKeyValue("Days_working_out_gym", value + " days"); ui_handler.showNextPanel(); }
    public void submitTimeActive() { updateValue(); ui_handler.AddKeyValue("Time_active", value + ":00"); ui_handler.showNextPanel(); }
    public void submitHoursSitting() { updateValue(); ui_handler.AddKeyValue("Hours_sitting", value + "h"); ui_handler.showNextPanel(); }
    public void submitHoursSleeping() { updateValue(); ui_handler.AddKeyValue("Hours_sleeping", value + "h"); ui_handler.showNextPanel(); }

    public void updateValue()
    {
        value = slider.value.ToString();
        outText.text = value;
    }
}
