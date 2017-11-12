using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBackPanText : MonoBehaviour {

    public GameObject quitText;
    public GameObject instrText;

	// Use this for initialization
	void Start () {
        quitText.SetActive(false);
        instrText.SetActive(false);
	}

    public void showQuitText()
    {
        instrText.SetActive(false);
        quitText.SetActive(true);
        quitText.GetComponent<AudioSource>().Play();
    }

    public void showInstrText()
    {
        quitText.SetActive(false);
        instrText.SetActive(true);
        instrText.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
