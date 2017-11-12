using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;

    void Start ()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }


    public void Update ()
    {
        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();
        } else {
            PickupObject();
        }
    }

    void Carry (GameObject o)
    {
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.transform.position = Vector3.Lerp (o.transform.position, 
            mainCamera.transform.position + mainCamera.transform.forward * distance,
            Time.deltaTime * smooth);
    }

    public void PickupObject ()
    {
        if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    void CheckDrop ()
    {
        if(Input.GetMouseButtonUp(0))
        {
            DropObject();
        }
    }

    public void DropObject ()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
