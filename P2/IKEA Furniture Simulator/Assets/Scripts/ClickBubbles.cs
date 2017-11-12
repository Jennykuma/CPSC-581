using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBubbles : MonoBehaviour {

    public GameObject bubbleFront1;
    public GameObject bubbleFront2;
    public GameObject bubbleFront3;
    public GameObject bubbleBottom1;
    public GameObject bubbleRight1;
    public GameObject bubbleRight2;
    public GameObject bubbleLeft1;
    public GameObject bubbleBack1;

    public GameObject gotItBtn;

    public AudioSource uCanDoThis;
    public AudioSource dontGiveUp;

    static int counter;

    RaycastHit hit;
    Ray ray;

    // Use this for initialization
    void Start () {
        counter = 8;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //empty RaycastHit object which raycast puts the hit details into
            //ray shooting out of the camera from where the mouse is
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

    public void BubbleDisappear()
    {
        int chance = Random.Range(1, 1000);
        if (Physics.Raycast(ray, out hit)) // add to array
        {
            if (hit.collider.gameObject.tag == "bubble")
            {
                Debug.Log("hit");
                hit.collider.gameObject.SetActive(false);
                counter--;
                if(chance % 2 == 0)
                {
                    uCanDoThis.Play();
                } else
                {
                    dontGiveUp.Play();
                }
                Debug.Log("DEBUGMSG: " + counter);
            }
        }

        if (counter == 0 || counter == 1 || counter == 2)
        {
            gotItBtn.SetActive(true);
        }
    }
}
