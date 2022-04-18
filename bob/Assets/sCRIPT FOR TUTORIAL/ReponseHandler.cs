using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReponseHandler : MonoBehaviour
{

    [SerializeField] private RectTransform reponseBox;
    [SerializeField] private RectTransform reponseButtonTemplate;
    [SerializeField] private RectTransform reponseContainer;


    private List<GameObject> tempreponseButton = new List<GameObject>();


    

    private ScriptForDialog dialogueUI;

    private void Start()
    {
        dialogueUI = GetComponent<ScriptForDialog>();
    }
    public void ShowReponses(Reponse[] reponses)
    {

        float reponseBoxHeight = 0;

        foreach (Reponse reponse in reponses)
        {

            GameObject reponseButton = Instantiate(reponseButtonTemplate.gameObject, reponseContainer);
            reponseButton.gameObject.SetActive(true);
            reponseButton.GetComponent<TMP_Text>().text = reponse.Reponsetext;
            reponseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedReponse(reponse));

            tempreponseButton.Add(reponseButton);
            reponseBoxHeight += reponseButtonTemplate.sizeDelta.y;
        }
       


    }

    public void OnPickedReponse(Reponse reponse)
    {

        reponseBox.gameObject.SetActive(false);
        foreach  (GameObject Button in tempreponseButton)
        {
            Destroy(Button);
        }

        tempreponseButton.Clear();
        Debug.Log(reponse.DialogObject.Dialogue[0]);
        dialogueUI.ShowDialogue(reponse.DialogObject);
    }


}
