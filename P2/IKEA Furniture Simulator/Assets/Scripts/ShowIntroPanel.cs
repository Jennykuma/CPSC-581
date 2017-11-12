using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIntroPanel : MonoBehaviour {

    public GameObject introPanel;
    public GameObject simIntroPanel;

	// Use this for initialization
	void Start () {
        simIntroPanel.SetActive(false);
	}

    public void ShowSimIntroPanel ()
    {
        introPanel.SetActive(false);
        simIntroPanel.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
