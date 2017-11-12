using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstrPanels : MonoBehaviour {

    public GameObject instrPanel1;
    public GameObject instrPanel2;

    // Use this for initialization
    void Start () {
        instrPanel1.SetActive(false);
        instrPanel2.SetActive(false);
	}

    public void ShowPanels ()
    {
        instrPanel1.SetActive(true);
        instrPanel2.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
