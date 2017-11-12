using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText_MouseOver : MonoBehaviour {

    public GameObject text;

	// Use this for initialization
	void Start () {
        text.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseOver()
    {
        text.SetActive(true);
    }

    public void OnMouseExit()
    {
        text.SetActive(false);
    }
}
