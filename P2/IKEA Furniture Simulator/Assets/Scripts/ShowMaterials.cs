using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMaterials : MonoBehaviour {

    public GameObject ikeaBox;
    public GameObject topDesk;
    public GameObject legDesk;
    public GameObject legDesk2;
    public GameObject drawer1;
    public GameObject drawer2;
    public GameObject drawer3;
    public GameObject shorterBeam1;
    public GameObject shorterBeam2;
    public GameObject longerBeam;

    public AudioSource lookBehind;

    // Use this for initialization
    void Start () {
        topDesk.SetActive(false);
        legDesk.SetActive(false);
        legDesk2.SetActive(false);
        drawer1.SetActive(false);
        drawer2.SetActive(false);
        drawer3.SetActive(false);
        shorterBeam1.SetActive(false);
        shorterBeam2.SetActive(false);
        longerBeam.SetActive(false);
    }

    void OnCollisionEnter()
    {
        ikeaBox.GetComponent<AudioSource>().Play();
    }

    public void hideBox ()
    {
        ikeaBox.SetActive(false);
        topDesk.SetActive(true);
        legDesk.SetActive(true);
        legDesk2.SetActive(true);
        drawer1.SetActive(true);
        drawer2.SetActive(true);
        drawer3.SetActive(true);
        shorterBeam1.SetActive(true);
        shorterBeam2.SetActive(true);
        longerBeam.SetActive(true);
        lookBehind.Play();
    }
}
