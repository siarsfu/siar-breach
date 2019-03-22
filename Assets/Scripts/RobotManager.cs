using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour {


    public Renderer[] allRenderers;

	// Use this for initialization
	void Start () {
        allRenderers = this.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void makeRobotDisappear(){
        for (int i = 0; i < allRenderers.Length; i++)
        {
            Renderer renderer = allRenderers[i];
            renderer.enabled = false;
        }
    }
}
