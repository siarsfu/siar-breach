using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DisplayInit : MonoBehaviour
{
    // Class takes care of assigning which Display shows what.
    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    public Camera ui_cam;
    public GameObject our_ui;
    private bool doneWithUserUI;
    private bool doneWithOurUI;

    //////////////////////////////////////////////////////////////////////////// START ///////////////////////////////////////////////////////////////////////
    void Start()
    {

        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        //if (Display.displays.Length > 1) Display.displays[1].Activate();

        //set up the Displays to render to correct screens.
        ui_cam.targetDisplay = 1;
        our_ui.SetActive(false);
    }

    //////////////////////////////////////////////////////////////////////////// UPDATE //////////////////////////////////////////////////////////////////////
    void Update()
    {
        //mirror Rift view (only active when Our UI is showing && while CTRL is held)
        if ((doneWithUserUI && !doneWithOurUI) && (Input.GetKeyDown(KeyCode.RightControl)))
        {
            ui_cam.targetDisplay = 1;
            our_ui.SetActive(false);
        }
        if ((doneWithUserUI && !doneWithOurUI) && (Input.GetKeyUp(KeyCode.RightControl)))
        {
            ui_cam.targetDisplay = 0;
            our_ui.SetActive(true);
        }
    }

    public void setDoneWithUserUI()
    {
        doneWithUserUI = true;
        //ui_cam.targetDisplay = 0;
    }

    public void setDoneWithOurUI() {
        //ui_cam.targetDisplay = 1;
        our_ui.SetActive(false);
        doneWithOurUI = true;
    }


}
