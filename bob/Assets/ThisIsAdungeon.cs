using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThisIsAdungeon : MonoBehaviour
{

    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
           
            
                ui.SetActive(true);
            
            StartCoroutine("WaitForSeconds");
            
               
           

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {


    //        ui.SetActive(false);



    //    }
    //}
    IEnumerator WaitForSeconds()
    {
       
        yield return new WaitForSeconds(5);

        Destroy(ui);
        Destroy(gameObject);


    }
}
