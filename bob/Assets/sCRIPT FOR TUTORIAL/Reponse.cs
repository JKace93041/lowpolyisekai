using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]




public class Reponse
{

    [SerializeField] private string reponsetext;
    [SerializeField] private DialogObject dialogueObject;

    public string Reponsetext => reponsetext;
    public DialogObject DialogObject => dialogueObject;



}
