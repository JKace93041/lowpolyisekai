using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogObject : ScriptableObject
{

    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Reponse[] reponses;

    public bool HasResponses => reponses != null && reponses.Length > 0;


    public string[] Dialogue => dialogue;
    public Reponse[] Reponses => reponses;

}
