using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{


    [SerializeField] public float typerwriterSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textlabel)
    {
         return StartCoroutine(TypeText(textToType, textlabel));


    }
    private IEnumerator TypeText(string textToType , TMP_Text textlabel)
    {
        float t = 0;
        int charindex = 0;
        while(charindex < textToType.Length)
        {

            t += typerwriterSpeed * Time.deltaTime;
            charindex = Mathf.FloorToInt((t));
            charindex = Mathf.Clamp(charindex, 0, textToType.Length);

            textlabel.text = textToType.Substring(0, charindex);


            yield return null;

        }

        textlabel.text = textToType;
    }



}
