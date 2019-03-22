using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DisplayInit : MonoBehaviour
{
    public Camera ui_cam;
    public GameObject our_ui;
    private bool doneWithUserUI;

    // Use this for initialization
    void Start()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);

        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1) Display.displays[1].Activate();
        if (Display.displays.Length > 2) Display.displays[2].Activate();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ui_cam.targetDisplay = 1;
            our_ui.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            ui_cam.targetDisplay = 0;
            if (doneWithUserUI) our_ui.SetActive(true);
        }
    }

    public void setDoneWithUserUI()
    {
        doneWithUserUI = true;
    }


}
