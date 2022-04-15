using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptForDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text textlabel;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private DialogObject testdialogue;
    private Typewriter typewriterEffect;
 
 private ReponseHandler reponseHandler;

    private void Start()
    {


        //GetComponent<Typewriter>().Run("hi my name is bobby brown", textlabel);


        typewriterEffect = GetComponent<Typewriter>();
        reponseHandler = GetComponent<ReponseHandler>();
        CloseDialogueBox();

        ShowDialogue(testdialogue);


    }

    public void ShowDialogue(DialogObject dialogueObject)
    {


        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));

    }

private IEnumerator StepThroughDialogue(DialogObject dialogObject)
    {

        //foreach(string dialogue in dialogObject.Dialogue)
        //{
        //    yield return typewriterEffect.Run(dialogue, textlabel);
        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));


        //}
        for (int i = 0; i < dialogObject.Dialogue.Length; i++)
        {
            string dialogue = dialogObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textlabel);
            //yield return RunTypingEffect(dialogue);
            textlabel.text = dialogue;


            if (i == dialogObject.Dialogue.Length - 1 && dialogObject.HasResponses)
                break;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if(dialogObject.HasResponses)
        {

            reponseHandler.ShowReponses(dialogObject.Reponses);


        }
        else
        {
            CloseDialogueBox();

        }


      
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textlabel.text = string.Empty;


    }


}
