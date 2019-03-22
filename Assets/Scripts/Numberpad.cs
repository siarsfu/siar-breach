using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Numberpad : MonoBehaviour {
    string value;
    public TMP_Text outText;
    public TMP_Text outUnit;
    public UI_Handler ui_handler;
    public Button button;
    public GameObject ft_display;
    public bool age;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pressZero() { value = value + "0"; UpdateText(); }
    public void pressOne() { value = value + "1"; UpdateText(); }
    public void pressTwo() { value = value + "2"; UpdateText(); }
    public void pressThree() { value = value + "3"; UpdateText(); }
    public void pressFour() { value = value + "4"; UpdateText(); }
    public void pressFive() { value = value + "5"; UpdateText(); }
    public void pressSix() { value = value + "6"; UpdateText(); }
    public void pressSeven() { value = value + "7"; UpdateText(); }
    public void pressEight() { value = value + "8"; UpdateText(); }
    public void pressNine() { value = value + "9"; UpdateText(); }
    public void pressKG() { outUnit.text = "kg"; }
    public void pressLB() { outUnit.text = "lb"; }
    public void pressCM() { outUnit.text = "cm"; ft_display.SetActive(false); }
    public void pressFT() { outUnit.text = ""; ft_display.SetActive(true); }
    public void pressBack() { value = value.Remove(value.Length - 1); UpdateText(); }
    public void pressSubmitWeight () { ui_handler.AddKeyValue("Weight", value + outUnit.text); ui_handler.showNextPanel(); }
    public void pressSubmitHeight() {
        //ft
        if (string.Compare(outUnit.text, "") == 0) {
            if (value.Length == 2) value = value[0] + "0" + value[1];
            ui_handler.AddKeyValue("Height", value[0] + "\'" + value[1] + value[2] + "\"");
        } else //cm
        {
            ui_handler.AddKeyValue("Height", value + outUnit.text);
        }
        ui_handler.showNextPanel();
    }
    public void pressSubmitAge() { 
        string birthdate = ""+value[0]+value[1]+"."+value[2]+value[3]+"."+value[4]+value[5]+value[6]+value[7];
        ui_handler.AddKeyValue("Birthdate", birthdate); 
        ui_handler.showNextPanel();
        Debug.Log("birthdate: " + birthdate);
    }



    private void UpdateText()
    {
        if (age) {
            if (value.Length <= 8)
            {
                outText.text = value;
                if (value.Length == 8)
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
            else
            {
                value = value.Remove(value.Length - 1);
            }
        }
        else
        {
            if (value.Length <= 3)
            {
                outText.text = value;
                if (value.Length >= 2)
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
            else
            {
                value = value.Remove(value.Length - 1);
            }
        }
    }
    

}
