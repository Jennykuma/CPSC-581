using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFullPart : MonoBehaviour {

    public GameObject part;

	// Use this for initialization
	void Start () {
        part.SetActive(false);
	}

    public void Show ()
    {
        part.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
