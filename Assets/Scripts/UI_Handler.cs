using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;


public class UI_Handler : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////// FIELDS //////////////////////////////////////////////////////////////////////
    //UI + EventSystem
    public GameObject User_UI;
    public GameObject Our_UI;
    public Transform trackingSpace;
    public GameObject MyEventSystem;
    private StandaloneInputModule pcInput;
    private ControllerSelection.OVRInputModule vrInput;
    public TMP_Text dataDumpText;

    //Final Screens
    public GameObject finalScreens;
    public TMP_Text frontText;
    public TMP_Text backText;
    public TMP_Text leftTextL;
    public TMP_Text leftTextR;
    public TMP_Text rightTextL;
    public TMP_Text rightTextR;
    public TMP_Text topText_name;
    public TMP_Text topText_age;
    public TMP_Text topText_hair;
    public TMP_Text topText_eyes;
    public TMP_Text topText_gender;
    public TMP_Text topText_weight;
    public TMP_Text topText_height;
    public TMP_Text bottomText;

    public DisplayInit displayInit;

    public Typewriter firstTypewriter;
    public Typewriter reverseTypewriter;
    public Typewriter reverseTypewriter2;
    public Typewriter reverseTypewriter3;
    public Typewriter reverseTypewriter4;
    public Typewriter reverseTypewriter5;
    public Typewriter reverseTypewriter6;

    public FlickerLights flickerLights;
    public GameObject deletePanel;

    private int curPanel = 0;

    public GameObject selectionVisualizer;

    public TimeDisplay timeDisplay;

    public GameObject ourIdImg;
    public GameObject runningCode;

    public AudioSource dialUp;

    public Auction auction;

    public Instructor instructor;
    

    //Processing Values
    public Hashtable dataTable = new Hashtable();
    private string dataTableString = "";

    GameObject[] user_UI_Panels = new GameObject[14]; //<-------- Hardcoded: set number of panels

    ////////////////////////////////////////////////////////////////////////////// START ////////////////////////////////////////////////////
    void Awake()
    {
       
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
        Init_UI_system();
    }

    ///////////////////////////////////////////////////////////////////////////// UPDATE ////////////////////////////////////////////////////
    void Update()
    {
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

    //////////////////////////////////////////////////////////////////////////////// AddKeyValue 
    public void AddKeyValue(string key, string value)
    {
        dataTable.Add(key, value);
        dataTableString = dataTableString + key + ": " + value + "\n";
        Debug.Log("UI_Handler: Hashtable entry added: key=" + key + "  |  value=" + value);
    }


    ///////////////////////////////////////////////////////////////////////// FILL TEXT OF FINAL SCREENS 
    public void setLeftWall()
    {
        
        string leftWallL = (string)leftTextL.text;
        string leftWallR = (string)leftTextR.text;

        //############## parse left column
        //leftWallL = leftWallL.Replace("#NAME#", (string)dataTable["Name"]);
        leftWallL = leftWallL.Replace("#DOB#", (string)dataTable["Birthdate"]);
        leftWallL = leftWallL.Replace("#GENDER#", (string)dataTable["Gender"]);
        //leftWallL = leftWallL.Replace("#PHONE#", (string)dataTable["Phone"]);
        //leftWallL = leftWallL.Replace("#EMAIL#", (string)dataTable["EMail"]);
        leftWallL = leftWallL.Replace("#H_UNIT#", (string)dataTable["H_Unit"]);
        leftWallL = leftWallL.Replace("#W_UNIT#", (string)dataTable["W_Unit"]);
        leftWallL = leftWallL.Replace("#HEIGHT#", (string)dataTable["Height"]);
        leftWallL = leftWallL.Replace("#WEIGHT#", (string)dataTable["Weight"]);

        //############## parse right column
        
        if (dataTable.ContainsKey("Place_of_birth")) {
            leftWallR = leftWallR.Replace("#POB#", (string)dataTable["Place_of_birth"]); 
        } else {
            leftWallR = leftWallR.Replace("#POB#", "unavailable"); 
        }
        if (dataTable.ContainsKey("Current_residence")) {
            leftWallR = leftWallR.Replace("#RESIDENCE#", (string)dataTable["Current_residence"]); 
        } else {
            leftWallR = leftWallR.Replace("#RESIDENCE#", "unavailable"); 
        }
        if (dataTable.ContainsKey("Frequent_location")) {
            leftWallR = leftWallR.Replace("#FREQUENT#", (string)dataTable["Frequent_location"]);
        } else {
            leftWallR = leftWallR.Replace("#FREQUENT#", "unavailable");
        }

        //############## set text
        leftTextL.text = leftWallL;
        leftTextR.text = leftWallR;
        
    }

    public void setRightWall()
    {
        string rightWallL = (string)rightTextL.text;
        string rightWallR = (string)rightTextR.text;

        //##############prepare for parsing: limit amount of brands
        string allBrands = (string)dataTable["Favorite_Sportsbrands"];
        string[] allBrandsArray = allBrands.Split(',');
        string limitedBrands = "";
        for (int i = 0; i < 5; i++)
        {
            string seperator = "";
            if (i > 0) seperator = ",";
            if (allBrandsArray.Length > i) limitedBrands = limitedBrands + seperator + allBrandsArray[i];
        }

        //############## parse left column
        rightWallL = rightWallL.Replace("#DOB#", (string)dataTable["Birthdate"]);
        rightWallL = rightWallL.Replace("#GENDER#", (string)dataTable["Gender"]);
        rightWallL = rightWallL.Replace("#H_UNIT#", (string)dataTable["H_Unit"]);
        rightWallL = rightWallL.Replace("#W_UNIT#", (string)dataTable["W_Unit"]);
        rightWallL = rightWallL.Replace("#HEIGHT#", (string)dataTable["Height"]);
        rightWallL = rightWallL.Replace("#WEIGHT#", (string)dataTable["Weight"]);
        rightWallL = rightWallL.Replace("#SLEEP#", (string)dataTable["Hours_sleeping"]);
        rightWallL = rightWallL.Replace("#DRUGS#", (string)dataTable["Drugs_consumed"]);

        //############## parse right column
        rightWallR = rightWallR.Replace("#SITTINGHRS#", (string)dataTable["Hours_sitting"]);
        rightWallR = rightWallR.Replace("#CALORIES#", (string)dataTable["Calories"]);
        rightWallR = rightWallR.Replace("#ACTIVITYLEVEL#", (string)dataTable["Activity_Level"]);
        rightWallR = rightWallR.Replace("#HOMEWORKOUT#", (string)dataTable["Days_working_out_home"]);
        rightWallR = rightWallR.Replace("#GYMWORKOUT#", (string)dataTable["Days_working_out_gym"]);
        rightWallR = rightWallR.Replace("#BRANDCHOICE#", limitedBrands);

        //set text
        rightTextL.text = rightWallL;
        rightTextR.text = rightWallR;
    }

    public void setID()
    {
        string formattedname = "" + (string)dataTable["LName"] + ", \n" + (string)dataTable["FName"];
        //topText_name.text = formattedname;
        //topText_hair.text = (string)dataTable["Hair"];
        //topText_eyes.text = (string)dataTable["Eyes"];
        string genderString = "";
        if (((string)dataTable["Gender"]).Equals("Male")) genderString = "M"; if (((string)dataTable["Gender"]).Equals("Female")) genderString = "F";
        if (((string)dataTable["Gender"]).Equals("Other")) genderString = "X"; if (((string)dataTable["Gender"]).Equals("Not Specified")) genderString = "X";
        topText_gender.text = genderString;
        string ageString = (string)dataTable["Birthdate"];
        ageString = "" + ageString[8] + ageString[9] + "   " + ageString[3] + ageString[4] + "   " + ageString[0] + ageString[1];
        topText_age.text = ageString;
        topText_weight.text = "" + (string)dataTable["Weight"] + (string)dataTable["W_Unit"];
        topText_height.text = "" + (string)dataTable["Height"] + (string)dataTable["H_Unit"];

        timeDisplay.startBreach();
    }

    ///////////////////////////////////////////////////////////// turnOnDataBreachScreens() & turnOffDataBreachScreens() 
    /// TURN ON DATA BREACH SCREENS
    public void turnOnDataBreachScreens()
    {
        finalScreens.SetActive(true);
        firstTypewriter.animateText();

        Debug.Log("done turning on data breach Screens");

        Our_UI.GetComponent<Our_UI>().reenableButton();
    }

    public void turnOffDataBreachScreens()
    {
        finalScreens.SetActive(false);

        Debug.Log("done turning off data breach Screens");
    }


    ///////////////////////////////////////////////////////////////////// showNextPanel() & finalButton() 
    public void showNextPanel()
    {
        user_UI_Panels[curPanel].SetActive(false);
        if (!(curPanel == user_UI_Panels.Length - 1))
        {
            Debug.Log("going to next panel");
            curPanel++;
            user_UI_Panels[curPanel].SetActive(true);
        }
        else {
            Debug.Log("final_button");
            FinalButton(); 
        }
    }

    public void FinalButton()
    {
        //Switch Eventsystem to Mouse input
        Debug.Log("EventSystem switched to: PC");
        User_UI.SetActive(false);
        Our_UI.SetActive(true);
        //pcInput.enabled = true;
        //vrInput.enabled = false;
        //MyEventSystem.GetComponent<EventSystem>().UpdateModules();
        //make sure Cursor is visible
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //add data to pc UI
        displayCollectedData();
        displayInit.setDoneWithUserUI();
        //disable Pointer line
        selectionVisualizer.SetActive(false);
        instructor.startYogaSequence();
    }

    public void switchESbackToVR()
    {
        //Switch Eventsystem to Mouse input
        Debug.Log("EventSystem switched to: VR");
        Our_UI.SetActive(false);
        //pcInput.enabled = false;
        //vrInput.enabled = true;
        //MyEventSystem.GetComponent<EventSystem>().UpdateModules();
        //make sure Cursor is visible
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
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
        //ui_data = dataTableString;

        Debug.Log("data dumped");
    }

    //////////////////////////////////// User Breach Buttons
    public void userBreachDelete() {
        deletePanel.SetActive(false);
        runningCode.SetActive(false);
        ourIdImg.SetActive(false);
        auction.stopAuction();
        dialUp.Play();
        timeDisplay.startABreach();
        flickerLights.stopBreachAmbient();
        reverseTypewriter.reverseAnimateText();
        reverseTypewriter2.reverseAnimateText();
        reverseTypewriter3.reverseAnimateText();
        reverseTypewriter4.reverseAnimateText();
        reverseTypewriter5.reverseAnimateText();
        reverseTypewriter6.reverseAnimateText();
    }

    public void userBreachKeep() {
        deletePanel.SetActive(false);
        runningCode.SetActive(false);
        flickerLights.revertToNormal();
        timeDisplay.startABreach();
    }


    public Hashtable gimmeDatabase() {
        return dataTable;
    }

    public void activatePointer() {
        selectionVisualizer.SetActive(true);
    }
   
}
