using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showPanel : MonoBehaviour {

    public GameObject IntroPanel;
    public GameObject CataloguePanel;
    public GameObject InstructionsPanel;
    public GameObject bubbleFront1;
    public GameObject bubbleFront2;
    public GameObject bubbleFront3;
    public GameObject bubbleBottom1;
    public GameObject bubbleRight1;
    public GameObject bubbleRight2;
    public GameObject bubbleLeft1;
    public GameObject bubbleBack1;
    public GameObject gotItBtn;

    // Use this for initialization
    void Start () {
        bubbleFront1.SetActive(false);
        bubbleFront2.SetActive(false);
        bubbleFront3.SetActive(false);
        bubbleBottom1.SetActive(false);
        bubbleRight1.SetActive(false);
        bubbleRight2.SetActive(false);
        bubbleLeft1.SetActive(false);
        bubbleBack1.SetActive(false);
        gotItBtn.SetActive(false);
    }

    IEnumerator BubbleAppear()
    {
        yield return new WaitForSeconds(0.5f);
        bubbleFront1.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleFront2.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleFront3.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleBottom1.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleRight1.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleRight2.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleLeft1.SetActive(true);
        yield return new WaitForSeconds(1);
        bubbleBack1.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
    }

    public void Show ()
    {
        IntroPanel.SetActive(false);
        CataloguePanel.SetActive(false);
        InstructionsPanel.SetActive(true);

        StartCoroutine(BubbleAppear());
    }
}
