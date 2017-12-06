using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    private List<BodyGameObject> bodies = new List<BodyGameObject>();

    public GameObject brownPot;
    public GameObject whitePot;
    public GameObject finalBrownPot;
    public GameObject fantasyPot;

    public AudioSource pop;
    public AudioSource dirt;
    public AudioSource water;
    public AudioSource levelup;
    public AudioSource yay;

    public static bool brownPotChosen = false;
    public static bool whitePotChosen = false;
    public static bool setScale = true;
    public static bool askFirst = true;
    public static bool askSecond = false;
    public static bool askThird = false;
    public static bool done = false;
    public static int[] answer = new int[3];


    public CanvasRenderer pickPotScreen;
    public CanvasRenderer fillPotScreen;
    public CanvasRenderer question1Screen;
    public CanvasRenderer question2Screen;
    public CanvasRenderer question3Screen;
    public CanvasRenderer emptyDesk;

    public GameObject a1;
    public GameObject a2;
    public GameObject a4;
    public GameObject a7;
    public GameObject soilBrown;
    public GameObject soilWhite;

    public GameObject aHome;
    public GameObject aOutside;
    public GameObject waterBrown;

    public GameObject aAccepting;
    public GameObject aGenerosity;
    public GameObject aKindness;
    public GameObject aLoyalty;
    public GameObject sunlight;

    public GameObject fantasyPlant;
    public GameObject bigPlant;
    public GameObject fancyPlant;

    // Use this for initialization
    void Start () {
        fillPotScreen.SetAlpha(0);
        question1Screen.SetAlpha(0);
        question2Screen.SetAlpha(0);
        question3Screen.SetAlpha(0);

        soilBrown.SetActive(false);
        soilWhite.SetActive(false);
        a1.SetActive(false);
        a2.SetActive(false);
        a4.SetActive(false);
        a7.SetActive(false);

        aHome.SetActive(false);
        aOutside.SetActive(false);
        waterBrown.SetActive(false);

        aAccepting.SetActive(false);
        aGenerosity.SetActive(false);
        aKindness.SetActive(false);
        aLoyalty.SetActive(false);
        sunlight.SetActive(false);

        bigPlant.SetActive(false);
        fancyPlant.SetActive(false);
        fantasyPlant.SetActive(false);
        fantasyPot.SetActive(false);
        finalBrownPot.SetActive(false);
}
	
	// Update is called once per frame
	void LateUpdate () {
		if(bodies.Count > 0)
        {
            GameObject handLeft = bodies[0].GetJoint(Windows.Kinect.JointType.HandLeft);
            GameObject handRight = bodies[0].GetJoint(Windows.Kinect.JointType.HandRight);


            Vector3 leftHPos = handLeft.transform.localPosition;
            Vector3 rightHPos = handRight.transform.localPosition;
            Vector3 brownPotPos = brownPot.transform.localPosition;
            Vector3 whitePotPos = whitePot.transform.localPosition;
            /*
            Debug.Log("leftHand X & Y: " + leftHPos.x + " , " + leftHPos.y);
            Debug.Log("whitePot X & Y: " + whitePotPos.x + " , " + whitePotPos.y);
            */
            if (!whitePotChosen) {
                if (((leftHPos.x <= brownPotPos.x + 6) && (leftHPos.x >= brownPotPos.x - 6)) && ((leftHPos.y <= brownPotPos.y + 25) && (leftHPos.y >= brownPotPos.y - 0.5))) {
                    Highlight(brownPot);
                    //Debug.Log("Should be highlighted");
                    brownPotChosen = true;
                } else
                {
                    Diffuse(brownPot);
                }
            }
            
                if (!brownPotChosen) {
                    if (((leftHPos.x <= whitePotPos.x + 16) && (leftHPos.x >= whitePotPos.x + 8)) && ((leftHPos.y <= whitePotPos.y + 25) && (leftHPos.y >= whitePotPos.y - 0.5)))
                    {
                        Highlight(whitePot);
                        //Debug.Log("white Should be highlighted");
                        whitePotChosen = true;
                    }
                    else
                    {
                        Diffuse(whitePot);
                    }
                }
            if (setScale) { 
                if (brownPotChosen)
                {
                    whitePot.SetActive(false);
                    brownPot.transform.Translate(new Vector3(5.3f, -17.6f, 113.8f));
                    brownPot.transform.Rotate(new Vector3(-80,0,0));
                    brownPot.transform.localScale += new Vector3(800 - brownPot.transform.localScale.x, 800 - brownPot.transform.localScale.y, 800 - brownPot.transform.localScale.z);
                    pop.Play();
                }
                else
                {
                    brownPot.SetActive(false);
                    whitePot.transform.Translate(new Vector3(whitePot.transform.localPosition.x + 43.3f, whitePot.transform.localPosition.y-12, whitePot.transform.localPosition.z -84));
                    whitePot.transform.Rotate(new Vector3(-80, 0, 0));
                    whitePot.transform.localScale += new Vector3(800 - whitePot.transform.localScale.x, 800 - whitePot.transform.localScale.y, 800 - whitePot.transform.localScale.z);
                    pop.Play();
                }
                setScale = false;
                pickPotScreen.SetAlpha(0);
                fillPotScreen.SetAlpha(100);
                //waitHere(50000);
                fillPotScreen.SetAlpha(0);
                question1Screen.SetAlpha(100);
                a1.SetActive(true);
                a2.SetActive(true);
                a4.SetActive(true);
                a7.SetActive(true);
            }
            
            if (askFirst)
            {
                //Debug.Log("leftHand X & Y: " + (leftHPos.x + 200)+ " , " + leftHPos.y);
               // Debug.Log("a1 X & Y: " + a2.transform.localPosition.x + " , " + a2.transform.localPosition.y);
                //Debug.Log(((leftHPos.x + 200 >= a7.transform.localPosition.x - 40) && (leftHPos.x + 200 <= a7.transform.localPosition.x - 35)));
                if (((leftHPos.x -200 >= a1.transform.localPosition.x-4) && (leftHPos.x - 200 <= a1.transform.localPosition.x - 2)) && ((leftHPos.y <= a1.transform.localPosition.y +20) && (leftHPos.y >= a1.transform.localPosition.y +10)))
                    {
                        soilBrown.SetActive(true);
                        Highlight(brownPot);
                        answer[0] = 1;
                        askFirst = false;
                        askSecond = true;
                        dirt.Play();
                    }
                    else if (((leftHPos.x - 200 >= a4.transform.localPosition.x - 4) && (leftHPos.x - 200 <= a4.transform.localPosition.x - 2)) && ((leftHPos.y >= a4.transform.localPosition.y + 170) && (leftHPos.y <= a4.transform.localPosition.y + 175)))
                {
                    soilBrown.SetActive(true);
                    Highlight(brownPot);
                    answer[0] = 4;
                    askFirst = false;
                    askSecond = true;
                    dirt.Play();
                } else if (((rightHPos.x + 200 >= a2.transform.localPosition.x - 40) && (rightHPos.x + 200 <= a2.transform.localPosition.x - 35)) && ((rightHPos.y <= a2.transform.localPosition.y + 20) && (rightHPos.y >= a2.transform.localPosition.y + 10)))
                {
                    soilBrown.SetActive(true);
                    Highlight(brownPot);
                    answer[0] = 2;
                    askFirst = false;
                    askSecond = true;
                    dirt.Play();
                }
                else if (((rightHPos.x + 200 >= a7.transform.localPosition.x - 40) && (rightHPos.x + 200 <= a7.transform.localPosition.x - 35)) && ((rightHPos.y >= a7.transform.localPosition.y + 170) && (rightHPos.y <= a7.transform.localPosition.y + 175)))
                {
                    soilBrown.SetActive(true);
                    Highlight(brownPot);
                    answer[0] = 7;
                    askFirst = false;
                    askSecond = true;
                    dirt.Play();
                }
           }
            //waitHere(50000);
            if (askSecond) {
                a1.SetActive(false);
                a2.SetActive(false);
                a4.SetActive(false);
                a7.SetActive(false);
                question1Screen.SetAlpha(0);
                question2Screen.SetAlpha(100);
                aHome.SetActive(true);
                aOutside.SetActive(true);

                if (((leftHPos.x - 200 >= aHome.transform.localPosition.x - 4) && (leftHPos.x - 200 <= aHome.transform.localPosition.x - 2)) && ((leftHPos.y <= aHome.transform.localPosition.y + 20) && (leftHPos.y >= aHome.transform.localPosition.y + 10)))
                {
                    waterBrown.SetActive(true);
                    Highlight(brownPot);
                    answer[1] = 1;
                    askSecond = false;
                    askThird = true;
                    water.Play();
                } else if (((rightHPos.x + 200 >= aOutside.transform.localPosition.x - 40) && (rightHPos.x + 200 <= aOutside.transform.localPosition.x - 35)) && ((rightHPos.y <= aOutside.transform.localPosition.y + 20) && (rightHPos.y >= aOutside.transform.localPosition.y + 10)))
                {
                    waterBrown.SetActive(true);
                    Highlight(brownPot);
                    answer[1] = 2;
                    askSecond = false;
                    askThird = true;
                    water.Play();
                }
            }
            //waitHere(50000);
            if (askThird)
            {
                aHome.SetActive(false);
                aOutside.SetActive(false);
                question2Screen.SetAlpha(0);
                question3Screen.SetAlpha(100);
                aAccepting.SetActive(true);
                aGenerosity.SetActive(true);
                aKindness.SetActive(true);
                aLoyalty.SetActive(true);
                if (((leftHPos.x - 200 >= aAccepting.transform.localPosition.x - 4) && (leftHPos.x - 200 <= aAccepting.transform.localPosition.x - 2)) && ((leftHPos.y <= aAccepting.transform.localPosition.y + 20) && (leftHPos.y >= aAccepting.transform.localPosition.y + 10)))
                {
                    sunlight.SetActive(true);
                    Highlight(brownPot);
                    answer[2] = 1;
                    askFirst = false;
                    askSecond = false;
                    askThird = false;
                    done = true;
                    levelup.Play();
                }
                else if (((leftHPos.x - 200 >= aKindness.transform.localPosition.x - 4) && (leftHPos.x - 200 <= aKindness.transform.localPosition.x - 2)) && ((leftHPos.y >= aKindness.transform.localPosition.y + 170) && (leftHPos.y <= aKindness.transform.localPosition.y + 175)))
                {
                    sunlight.SetActive(true);
                    Highlight(brownPot);
                    answer[2] = 2;
                    askFirst = false;
                    askSecond = false;
                    askThird = false;
                    done = true;
                    levelup.Play();
                }
                else if (((rightHPos.x + 200 >= aGenerosity.transform.localPosition.x - 40) && (rightHPos.x + 200 <= aGenerosity.transform.localPosition.x - 35)) && ((rightHPos.y <= aGenerosity.transform.localPosition.y + 20) && (rightHPos.y >= aGenerosity.transform.localPosition.y + 10)))
                {
                    sunlight.SetActive(true);
                    Highlight(brownPot);
                    answer[2] = 3;
                    askFirst = false;
                    askSecond = false;
                    askThird = false;
                    done = true;
                    levelup.Play();
                }
                else if (((rightHPos.x + 200 >= aLoyalty.transform.localPosition.x - 40) && (rightHPos.x + 200 <= aLoyalty.transform.localPosition.x - 35)) && ((rightHPos.y >= aLoyalty.transform.localPosition.y + 170) && (rightHPos.y <= aLoyalty.transform.localPosition.y + 175)))
                {
                    sunlight.SetActive(true);
                    Highlight(brownPot);
                    answer[2] = 4;
                    askFirst = false;
                    askSecond = false;
                    askThird = false;
                    done = true;
                    levelup.Play();
                }
            }
            if (done) {
                question3Screen.SetAlpha(0);
                emptyDesk.SetAlpha(100);
                aAccepting.SetActive(false);
                aGenerosity.SetActive(false);
                aKindness.SetActive(false);
                aLoyalty.SetActive(false);
                sunlight.SetActive(false);
                waterBrown.SetActive(false);
                soilBrown.SetActive(false);
                brownPot.SetActive(false);


                if ((answer[0] == 1 && answer[1] == 1 && answer[2] == 4) || (answer[0] == 2 && answer[1] == 1 && answer[2] == 4))
                {
                    //fantasy
                    fantasyPlant.SetActive(true);
                    fantasyPot.SetActive(true);
                    pop.Play();
                    finalBrownPot.SetActive(true);
                    brownPot.SetActive(false);
                    yay.Play();
                } else if ((answer[0] == 7 && answer[1] == 2 && answer[2] == 3))
                {
                    //left
                    bigPlant.SetActive(true);
                    pop.Play();
                    brownPot.SetActive(false);
                    yay.Play();
                } else if ((answer[0] == 4 && answer[1] == 2 && answer[2] == 1) || (answer[0] == 4 && answer[1] == 2 && answer[2] == 2))
                {
                    fancyPlant.SetActive(true);
                    pop.Play();
                    brownPot.SetActive(false);
                    yay.Play();
                }
                else
                {
                    fantasyPlant.SetActive(true);
                    pop.Play();
                    finalBrownPot.SetActive(true);
                    fantasyPot.SetActive(true);
                    yay.Play();
                }
            }

        }
    }

    void Highlight(GameObject pot)
    {
        pot.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    void Diffuse(GameObject pot)
    {
        pot.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
    }

    void Kinect_BodyFound(object args)
    {
        BodyGameObject bodyFound = (BodyGameObject)args;
        bodies.Add(bodyFound);
    }

    void Kinect_BodyLost(object args)
    {
        ulong bodyId = (ulong)args;
        for (int i = 0; i < bodies.Count; i++)
        {
            if (bodies[i].ID == bodyId)
            {
                bodies.RemoveAt(i);
                return;
            }
        }
    }

    IEnumerator WaitCoroutine(int seconds)

    {

        yield return new WaitForSeconds(seconds);
        Debug.Log("waitinggg");
        StartCoroutine(WaitCoroutine(seconds));
       
    }
}
