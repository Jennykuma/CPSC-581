using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInstrPart : MonoBehaviour {

    public GameObject leg1beam;
    public GameObject leg2beam;
    public GameObject leg3beam;
    public GameObject deskbothalf;
    public GameObject desknodrawer;
    public GameObject deskcomplete;

    public GameObject leg2beamInstr;
    public GameObject leg3beamInstr;
    public GameObject deskbothalfInstr;
    public GameObject desknodrawerInstr;
    public GameObject deskcompleteInstr;

    public GameObject instrPanel1;
    public GameObject instrPanel2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HidePart ()
    {
        if (leg2beam.GetComponent<Renderer>().isVisible && leg2beamInstr.GetComponent<Renderer>().isVisible)
        {
            leg2beamInstr.SetActive(false);
        } else if (leg3beam.GetComponent<Renderer>().isVisible && leg3beamInstr.GetComponent<Renderer>().isVisible)
        {
            leg3beamInstr.SetActive(false);
            instrPanel1.SetActive(false);
        } else if (deskbothalf.GetComponent<Renderer>().isVisible && deskbothalfInstr.GetComponent<Renderer>().isVisible)
        {
            deskbothalf.SetActive(false);
        } else if (desknodrawer.GetComponent<Renderer>().isVisible && desknodrawerInstr.GetComponent<Renderer>().isVisible)
        {
            desknodrawerInstr.SetActive(false);
        } else if (deskcomplete.GetComponent<Renderer>().isVisible && desknodrawerInstr.GetComponent<Renderer>().isVisible)
        {
            deskcompleteInstr.SetActive(false);
            instrPanel2.SetActive(false);
        }
    }
}
