using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject IntroPanel;
    public GameObject CataloguePanel;
    public GameObject InstructionsPanel;

    // Use this for initialization
    void Start () {
        IntroPanel.SetActive(!IntroPanel.activeSelf);
        CataloguePanel.SetActive(!CataloguePanel.activeSelf);
        InstructionsPanel.SetActive(InstructionsPanel.activeSelf);
    }

    public void Transition(PointerEventData eventData)
    {
        // OnClick code goes here ...
        CataloguePanel.SetActive(CataloguePanel.activeSelf);
        InstructionsPanel.SetActive(!InstructionsPanel.activeSelf);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // OnClick code goes here ...
        CataloguePanel.SetActive(CataloguePanel.activeSelf);
        InstructionsPanel.SetActive(!InstructionsPanel.activeSelf);
    }

}
