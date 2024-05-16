using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject nextDialogue;
    public float wordSpeed;
    public bool playerClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (dialogueBox.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogueBox.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        if(dialogueText.text == dialogue[index])
        {
            nextDialogue.SetActive(true);
        }
    }


    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

      //  nextDialogue.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

        nextDialogue.SetActive(false);
    }
}
