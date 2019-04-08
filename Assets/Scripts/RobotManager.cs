using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour {
    ////////////////////////////////////////////////////////////////////////////// FIELDS ////////////////////////////////////////////////////
    public Renderer[] allRenderers;

    ////////////////////////////////////////////////////////////////////////////// START ////////////////////////////////////////////////////
	void Start () {
        allRenderers = this.GetComponentsInChildren<Renderer>();
	}
	

    public void makeRobotDisappear(){
        for (int i = 0; i < allRenderers.Length; i++)
        {
            Renderer renderer = allRenderers[i];
            renderer.enabled = false;
        }
    }
}
