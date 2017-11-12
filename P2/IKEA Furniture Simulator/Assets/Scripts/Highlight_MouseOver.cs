using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_MouseOver : MonoBehaviour
{

   public void OnMouseOver()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

   public void OnMouseExit()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
    }
}