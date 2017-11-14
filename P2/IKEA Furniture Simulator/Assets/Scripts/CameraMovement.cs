using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public Transform vrCamera;
    public GameObject ControlPanel;
    public GameObject IntroPanel;
    public GameObject SimIntroPanel;
    public GameObject CataloguePanel;
    public GameObject InstructionsPanel;
    public GameObject LillasenImage;

    public AudioSource song;

    int i = 0;
    bool left = false;
    bool right = false;
    bool up = false;
    bool down = false;

    private Vector3 initPoint;

    static bool Control = true;
    static bool Intro = false;
    static bool SimIntro = false;

    // Use this for initialization
    void Start()
    {
        //Get the start point
        song.Play();
        initPoint = transform.position;
        ControlPanel.SetActive(true);
        IntroPanel.SetActive(false);
        SimIntroPanel.SetActive(false);
        CataloguePanel.SetActive(false);
        LillasenImage.SetActive(false);
        InstructionsPanel.SetActive(false);
    }

    public void SwitchToIntroPanel()
    {
        Control = false;
        ControlPanel.SetActive(false);
        Intro = true;
        IntroPanel.SetActive(true);
    }

    public void SwitchToSimPanel ()
    {
        Intro = false;
        IntroPanel.SetActive(false);
        SimIntro = true;
        SimIntroPanel.SetActive(true);
    }

    // Walk when looking Down
    void Update()
    {
        if (SimIntro == true)
        {
            i = i + 1;
            if (i == 100)
            {
                Checked();
                i = 0;
            }
        }
    }

    void Checked()
    {
        print("x: " + vrCamera.eulerAngles.x + " y: " + vrCamera.eulerAngles.y);
        for (int i = 0; i < 80; i++)
        {
            //print("Up: " + up + " Down: " + down+" Left: " + left + " Right: " + right);
            if (vrCamera.eulerAngles.y > 20.0f && vrCamera.eulerAngles.y < 90.0f && ((vrCamera.eulerAngles.x < 30.0f) || (vrCamera.eulerAngles.x > 350.0f)) && !right)
            {
                //print("right");
                right = true;
            }
            else if ((vrCamera.eulerAngles.y < 360.0f && vrCamera.eulerAngles.y > 290.0f) &&
                ((vrCamera.eulerAngles.x < 30.0f) || (vrCamera.eulerAngles.x > 350.0f)) && !left)
            {
                //print("left");
                left = true;
            }

            if (vrCamera.eulerAngles.x > 90.0f && ((vrCamera.eulerAngles.y > 340.0f) || (vrCamera.eulerAngles.y < 20.0f)) && !up)
            {
                //print("up");
                up = true;
            }
            else if (vrCamera.eulerAngles.x < 90.0f && ((vrCamera.eulerAngles.y > 340.0f) || (vrCamera.eulerAngles.y < 20.0f)) && !down)
            {
                //print("down");
                down = true;
            }
        }
        if (left && right)
        {
            print("no");
            left = false;
            right = false;
            up = false;
            down = false;
        }
        if (up && down)
        {
            print("yes");
            left = false;
            right = false;
            up = false;
            down = false;

            if (true)
            {
                SimIntroPanel.SetActive(false); // hide?
                CataloguePanel.SetActive(true); // show up...
                LillasenImage.SetActive(true);
                print("Catalogue should show up");
                song.Stop();
                this.enabled = false;
            }
        }
    }
}