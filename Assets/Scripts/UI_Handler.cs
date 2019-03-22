using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;


public class UI_Handler : MonoBehaviour
{

    //UI + EventSystem
    public GameObject User_UI;
    public GameObject Our_UI;
    public Transform trackingSpace;
    public GameObject MyEventSystem;
    private StandaloneInputModule pcInput;
    private ControllerSelection.OVRInputModule vrInput;
    public TMP_Text dataDumpText;
    public GameObject finalScreens;
    public TMP_Text frontText;
    public TMP_Text backText;
    public TMP_Text leftText;
    public TMP_Text rightText;
    public TMP_Text topText_name;
    public TMP_Text topText_age;
    public TMP_Text topText_hair;
    public TMP_Text topText_eyes;
    public TMP_Text bottomText;

    public TMP_Text soldEmailText;
    public TMP_Text soldConsumptionText;
    public TMP_Text soldGymText;
    public TMP_Text soldSittingText;
    public TMP_Text soldWeightText;

    public DisplayInit displayInit;

    private string companies_buying_data;
    private string id;
    private string ui_data;
    private string internet_and_observed_data;

    private int curPanel = 0;


    //Processing Values
    Hashtable dataTable = new Hashtable();
    private string dataTableString = "";

    GameObject[] user_UI_Panels = new GameObject[12]; //<-------- Hardcoded: set number of panels

    ////////////////////////////////////////////////////////////////////////////// START ////////////////////////////////////////////////////
    void Start()
    {
        Init_UI_system();
        //make sure Cursor is visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //get all User UI Panels, disable all but first
        for (int i = 0; i < user_UI_Panels.Length; i++)
        {
            if (i < 10) { user_UI_Panels[i] = GameObject.Find("Panel_0" + i); }
            else { user_UI_Panels[i] = GameObject.Find("Panel_" + i); }
        }
        for (int i = 1; i < user_UI_Panels.Length; i++) { user_UI_Panels[i].SetActive(false); }
    }

    ///////////////////////////////////////////////////////////////////////////// UPDATE ////////////////////////////////////////////////////
    void Update()
    {

    }

    public void FinalButton()
    {
        //Switch Eventsystem to Mouse input
        Debug.Log("test");
        User_UI.SetActive(false);
        Our_UI.SetActive(true);
        pcInput.enabled = true;
        vrInput.enabled = false;
        MyEventSystem.GetComponent<EventSystem>().UpdateModules();
        //make sure Cursor is visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //add data to pc UI
        displayCollectedData();
        displayInit.setDoneWithUserUI();
    }

    private void Init_UI_system()
    {
        //Enable Eventsystem VR input, disable PC input
        pcInput = MyEventSystem.GetComponent<StandaloneInputModule>();
        vrInput = MyEventSystem.GetComponent<ControllerSelection.OVRInputModule>();
        pcInput.enabled = false;
        vrInput.enabled = true;
        MyEventSystem.GetComponent<EventSystem>().UpdateModules();


    }

    public void AddKeyValue(string key, string value)
    {
        dataTable.Add(key, value);
        dataTableString = dataTableString + key + ": " + value + "\n";
        Debug.Log("UI_Handler: Hashtable entry added: key=" + key + "  |  value=" + value);
    }

    public void displayCollectedData()
    {
        string datadump = "";
        foreach (DictionaryEntry de in dataTable)
        {
            datadump = datadump + de.Key + ": " + de.Value + "\n";
        }

        //dataDumpText.text = datadump;
        //ui_data = datadump;
        dataDumpText.text = dataTableString;
        ui_data = dataTableString;

        Debug.Log("data dumped");
    }

    /// FILL CONTENT OF DATA BREACH SCREENS

    public void set_name_phone_email_and_ui_data(string phone_name_email)
    {
        string newString = phone_name_email + ui_data;
        ui_data = newString;
        frontText.text = ui_data;
    }

    public void set_ID_Card(string eyes, string hair, string name)
    {
        topText_name.text = name;
        string orig_bdate = dataTable["Birthdate"].ToString();
        string formatted_bdate = "" + orig_bdate[8] + orig_bdate[9] + " " + orig_bdate[3] + orig_bdate[4] + " " + orig_bdate[0] + orig_bdate[1];
        topText_age.text = formatted_bdate;
        topText_hair.text = hair;
        topText_eyes.text = eyes;
    }

    //email to facebook
    //consumptiom to amazon
    //time of working out to google
    //sitting/working time to instagram
    //weight to twitter

    public void setSoldWall(string email)
    {
        //sold email
        soldEmailText.text = email;

        //sold consumption
        string isAlcohol = (string)dataTable["Consumes: Alcohol"];
        string isCannabis = (string)dataTable["Consumes: Cannabis"];
        string isTobacco = (string)dataTable["Consumes: Tobacco"];
        string isOther = (string)dataTable["Consumes: Other Drugs"];

        string consumptionString = "";

        if (isAlcohol.Equals("true"))
            consumptionString += "alcohol ";
        if (isCannabis.Equals("true"))
            consumptionString += "cannabis ";
        if (isTobacco.Equals("true"))
            consumptionString += "tobacco ";
        if (isOther.Equals("true"))
            consumptionString += "other drugs ";

        //if (consumptionString[consumptionString.Length - 2] == ',')
        //{
        //    consumptionString.Remove(consumptionString[consumptionString.Length - 1]);
        //    consumptionString.Remove(consumptionString[consumptionString.Length - 1]);
        //}

        soldConsumptionText.text = "consumes " +consumptionString;

        //sold working out
        string workingOutTime = (string)dataTable["Time of the day typically working out at"];
        soldGymText.text = "usually works out at "+workingOutTime;

        //sold sitting time
        string sittingTime = (string)dataTable["Hours a day spent sitting"];
        soldSittingText.text = "sits " +sittingTime+" on one place";

        //sold weight
        string weightTime = (string)dataTable["Weight"];
        soldWeightText.text = "their weight is "+weightTime;
        
    }

    public void set_internet_and_observed_data(string input)
    {
        leftText.text = input;
    }





    /// TURN ON DATA BREACH SCREENS
    public void turnOnDataBreachScreens()
    {
        finalScreens.SetActive(true);

        Debug.Log("done turning on data breach Screens");
        Debug.Log(frontText.text);

        Our_UI.GetComponent<Our_UI>().reenableButton();
    }

    public void turnOffDataBreachScreens()
    {
        finalScreens.SetActive(false);

        Debug.Log("done turning on data breach Screens");
        Debug.Log(frontText.text);
    }


    public void showNextPanel()
    {
        user_UI_Panels[curPanel].SetActive(false);
        if (!(curPanel == user_UI_Panels.Length - 1))
        {
            curPanel++;
            user_UI_Panels[curPanel].SetActive(true);
        }
        else { FinalButton(); }
    }




   
}
