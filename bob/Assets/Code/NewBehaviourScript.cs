using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform spawnpoint;
    public bool canTeleport;
    public Transform TrasformtoTeleport;
    public GameObject ui;



    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            ui.SetActive(true);
            canTeleport = true;
            TrasformtoTeleport = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {


        if (other.tag == "Player")
        {

            ui.SetActive(false);
            canTeleport = true;
            TrasformtoTeleport = null;
        }
    }


    

    // Update is called once per frame
    void Update()
    {

        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            TrasformtoTeleport.position = spawnpoint.position;
        }


    }
}
