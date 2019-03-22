using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MySlider : MonoBehaviour
{
    string value = "";
    public Slider slider;
    public UI_Handler ui_handler;
    public TMP_Text outText;
    public Button submitBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submitCalories() { ui_handler.AddKeyValue("Calories consumed per day", value + "kcal"); ui_handler.showNextPanel(); }
    public void submitWater() { ui_handler.AddKeyValue("Litres water drank per day", value + "L"); ui_handler.showNextPanel(); }
    public void submitDaysHome() { ui_handler.AddKeyValue("Number of days working out at home", value + " days"); ui_handler.showNextPanel(); }
    public void submitDaysGym() { ui_handler.AddKeyValue("Number of days working out at a gym", value + " days"); ui_handler.showNextPanel(); }
    public void submitTimeActive() { ui_handler.AddKeyValue("Time of the day typically working out at", value + ":00"); ui_handler.showNextPanel(); }
    public void submitHoursSitting() { ui_handler.AddKeyValue("Hours a day spent sitting", value + "h"); ui_handler.showNextPanel(); }

    public void updateValue()
    {
        value = slider.value.ToString();
        outText.text = value;

        submitBtn.interactable = true;
    }
}
