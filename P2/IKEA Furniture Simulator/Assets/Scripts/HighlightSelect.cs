using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelect : MonoBehaviour {

    bool selected = false;

    static List<GameObject> parts = new List<GameObject>();

    public GameObject topDesk;
    public GameObject shortbeam1;
    public GameObject shortbeam2;
    public GameObject longbeam3;
    public GameObject deskleg1;
    public GameObject deskleg2;
    public GameObject drawer1;
    public GameObject drawer2;
    public GameObject drawer3;

    public GameObject leg1beam;
    public GameObject leg2beam;
    public GameObject leg3beam;
    public GameObject deskbothalf;
    public GameObject desknodrawer;
    public GameObject deskcomplete;
    public GameObject plane;

    public GameObject leg2beamInstr;
    public GameObject leg3beamInstr;
    public GameObject deskbothalfInstr;
    public GameObject desknodrawerInstr;
    public GameObject deskcompleteInstr;

    public GameObject instrPanel1;
    public GameObject instrPanel2;

    static bool firstPart = false;

    RaycastHit hit;
    RaycastHit[] hits;
    Ray ray;


    // Use this for initialization
    void Start () {
        leg1beam.GetComponent<MeshRenderer>().enabled = false;
        leg1beam.GetComponent<BoxCollider>().enabled = false;
        leg2beam.GetComponent<MeshRenderer>().enabled = false;
        leg2beam.GetComponent<BoxCollider>().enabled = false;
        leg3beam.GetComponent<MeshRenderer>().enabled = false;
        leg3beam.GetComponent<BoxCollider>().enabled = false;
        deskbothalf.GetComponent<MeshRenderer>().enabled = false;
        deskbothalf.GetComponent<BoxCollider>().enabled = false;
        desknodrawer.GetComponent<MeshRenderer>().enabled = false;
        desknodrawer.GetComponent<BoxCollider>().enabled = false;
        deskcomplete.GetComponent<MeshRenderer>().enabled = false;
        deskcomplete.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //empty RaycastHit object which raycast puts the hit details into
            //ray shooting out of the camera from where the mouse is
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

    public void OnPointerClick()
    {
        hits = Physics.RaycastAll(ray, Mathf.Infinity);
        for(int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            //Debug.Log("DEBUG: PRINTING OUT THE HITS - " + hits[i]);
        }

        //Debug.Log("DEBUG: CLICKITY");
        //Debug.Log("Hit distance" + hit.distance);
        
        if (Physics.Raycast(ray, out hit)) // add to array
        {
            //Debug.Log(hit.RaycastAll());
            /*
            if (hit.collider.tag == "NOTCLICK")
            {
                Debug.Log("PLANE CLICKED");
                //return;
            }*/

            //Debug.Log("What is being hit: " + hit.collider.gameObject.name);


            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Debug.Log("hit.collider.gameObject: " + hit.collider.gameObject);
            //Debug.Log("pls work");
            /*
            if (hit.collider.gameObject.tag != "NOTCLICK")
            {
                parts.Add(hit.collider.gameObject);
            }*/
            parts.Add(hit.collider.gameObject);


        }
        if(parts.Count == 2)
        {
            Debug.Log("Hellllo2");
            if (parts.Contains(deskleg1) && parts.Contains(shortbeam1)
            || (parts.Contains(deskleg1) && parts.Contains(shortbeam2))
            || (parts.Contains(deskleg2) && parts.Contains(shortbeam1))
            || (parts.Contains(deskleg2) && parts.Contains(shortbeam2))
            && (!firstPart))
            {
                print("part0: " + parts[0]);
                print("part1: " + parts[1]);
                firstPart = true;
                DeskLeg1Beam(parts[0], parts[1]);

            } else if (parts.Contains(leg1beam) && parts.Contains(shortbeam1)
                      || (parts.Contains(leg1beam) && parts.Contains(shortbeam2))
                      && (firstPart == true))
            {
                print("selected leg1beam and shortbeam");
                DeskLeg2Beam(parts[0], parts[1]);

            } else if (parts.Contains(leg2beam) && parts.Contains(longbeam3))
            {
                print("selected leg2beam and longbeam3");
                DeskLeg3Beam(parts[0], parts[1]);

            } else if (parts.Contains(leg3beam) && parts.Contains(deskleg2)
                      || (parts.Contains(leg3beam) && parts.Contains(deskleg1)))
            {
                print("selected leg3beam && deskleg2");
                DeskBottom(parts[0], parts[1]);

            } else if (parts.Contains(deskbothalf) && parts.Contains(topDesk))
            {
                print("selected bottom half of desk & top part of desk");
                DeskNoDrawers(parts[0], parts[1]);

            } else if (parts.Contains(desknodrawer) && parts.Contains(drawer1)
                      || (parts.Contains(desknodrawer) && parts.Contains(drawer2))
                      || (parts.Contains(desknodrawer) && parts.Contains(drawer3)))
            {
                print("drwaers and desknodrwaer selected");
                CompletedDesk(parts[0], parts[1]);

            }else {
                print("DEBUG: reset because wrong items");
                plane.GetComponent<AudioSource>().Play();
                parts[0].GetComponent<Renderer>().material.color = Color.white;
                parts[1].GetComponent<Renderer>().material.color = Color.white;
                parts.Clear();
            }
        }
        else
        {
            if(Physics.Raycast(ray, out hit))
            {
                print("DEBUG: " + hit.collider.name);
            }
        }
       
    }

    void DeskLeg1Beam(GameObject part1, GameObject part2)
    {
        leg1beam.GetComponent<MeshRenderer>().enabled = true;
        leg1beam.GetComponent<BoxCollider>().enabled = true;
        leg1beam.GetComponent<AudioSource>().Play();
        part1.SetActive(false);
        part2.SetActive(false);
        parts.Clear();
        print(parts.Count);
    }

    void DeskLeg2Beam(GameObject part1, GameObject part2)
    {
        leg2beam.GetComponent<MeshRenderer>().enabled = true;
        leg2beam.GetComponent<BoxCollider>().enabled = true;
        leg2beam.GetComponent<AudioSource>().Play();

        part1.SetActive(false);
        part2.SetActive(false);
        parts.Clear();
    }

    void DeskLeg3Beam(GameObject part1, GameObject part2)
    {
        leg3beam.GetComponent<MeshRenderer>().enabled = true;
        leg3beam.GetComponent<BoxCollider>().enabled = true;
        leg3beam.GetComponent<AudioSource>().Play();

        part1.SetActive(false);
        part2.SetActive(false);
        parts.Clear();
    }

    void DeskBottom(GameObject part1, GameObject part2)
    {
        deskbothalf.GetComponent<MeshRenderer>().enabled = true;
        deskbothalf.GetComponent<BoxCollider>().enabled = true;
        deskbothalf.GetComponent<AudioSource>().Play();

        part1.SetActive(false);
        part2.SetActive(false);
        parts.Clear();
    }

    void DeskNoDrawers(GameObject part1, GameObject part2)
    {
        desknodrawer.GetComponent<MeshRenderer>().enabled = true;
        desknodrawer.GetComponent<BoxCollider>().enabled = true;
        desknodrawer.GetComponent<AudioSource>().Play();

        part1.SetActive(false);
        part2.SetActive(false);
        parts.Clear();
    }

    void CompletedDesk(GameObject part1, GameObject part2)
    {
        deskcomplete.GetComponent<MeshRenderer>().enabled = true;
        deskcomplete.GetComponent<BoxCollider>().enabled = true;
        deskcomplete.GetComponent<AudioSource>().Play();

        instrPanel1.SetActive(false);
        instrPanel2.SetActive(false);

        part1.SetActive(false);
        part2.SetActive(false);
        drawer1.SetActive(false);
        drawer2.SetActive(false);
        drawer3.SetActive(false);
        parts.Clear();
    }

}
