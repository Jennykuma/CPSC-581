using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

    public GameObject obj;
    public AudioSource thumpSound;


	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter()
    {
        thumpSound.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
