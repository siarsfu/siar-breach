using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {
    //UI CLASS: For Panels with Toggles as Input type. Handles user input and submission of data to UI Handler.
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    public Toggle alcToggle;
    public Toggle canToggle;
    public Toggle tobToggle;
    public Toggle othToggle;
    public Toggle cafToggle;
    public UI_Handler ui_handler;

    public Toggle nikToggle;
    public Toggle adiToggle;
    public Toggle undToggle;
    public Toggle pumToggle;
    public Toggle skeToggle;
    public Toggle reeToggle;
    public Toggle norToggle;
    public Toggle oth2Toggle;

    private bool lightSleep;

    public void submitDrugs()
    {
        string drugsConsumed = "";
        if (alcToggle.isOn) drugsConsumed += "Alcohol, ";
        if (canToggle.isOn) drugsConsumed += "Cannabis, ";
        if (tobToggle.isOn) drugsConsumed += "Tobacco, ";
        if (cafToggle.isOn) drugsConsumed += "Caffeine, ";
        if (othToggle.isOn) drugsConsumed += "Other Drugs, ";
        if (!drugsConsumed.Equals(""))
        { 
            drugsConsumed = drugsConsumed.Remove(drugsConsumed.Length - 2);
        }
        else
        {
            drugsConsumed = "No drugs";
        }
        ui_handler.AddKeyValue("Drugs_consumed", drugsConsumed);
        ui_handler.showNextPanel();
    }

    public void submitBrands()
    {
        string favoriteBrands = "";
        if (nikToggle.isOn) favoriteBrands += "Nike, ";
        if (adiToggle.isOn) favoriteBrands += "Adidas, ";
        if (undToggle.isOn) favoriteBrands += "Under Armour, ";
        if (pumToggle.isOn) favoriteBrands += "Puma, ";
        if (skeToggle.isOn) favoriteBrands += "Skechers, ";
        if (reeToggle.isOn) favoriteBrands += "Reebok, ";
        if (norToggle.isOn) favoriteBrands += "Northface, ";
        if (oth2Toggle.isOn) favoriteBrands += "Other, ";
        if (!favoriteBrands.Equals(""))
        {
            favoriteBrands = favoriteBrands.Remove(favoriteBrands.Length - 2);
        }
        else
        {
            favoriteBrands = "unknown";
        }
        ui_handler.AddKeyValue("Favorite_Sportsbrands", favoriteBrands);
        ui_handler.showNextPanel();
    }
}
