using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{




  
        


            public GameObject ui;
            public bool canCollect;
            public bool collectOnEnter;

    public AudioSource collectSound;

            private void OnTriggerEnter(Collider other)
            {


                if (other.tag == "Player")
                {
                    if (collectOnEnter)
                    {
                        getCollected();
                    }
                    else
                    {
                        ui.SetActive(true);
                        canCollect = true;
                    }

                }
            }

            private void OnTriggerExit(Collider other)
            {


                if (other.tag == "Player")
                {

                    ui.SetActive(false);
                    canCollect = false;

                }

            }




            // Update is called once per frame
            void Update()
            {

                if (canCollect && Input.GetKeyDown(KeyCode.E))
                {
                    getCollected();
                }


            }
            public void getCollected()
            {

        ui.SetActive(false);
        //ADD A SSOUND AND DO SOMETHING COOOOOOOL LOLOLOLOLOLOL
        collectSound.Play();
        Destroy(gameObject);

            }




        

    }
