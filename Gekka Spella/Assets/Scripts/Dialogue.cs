using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject button;

    private int index = 0;


    void Start()
    {
        if (button.activeInHierarchy == true)
        {
            button.SetActive(false);

        }
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                Debug.Log(index);
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];

                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(textComponent.text == lines[index])
            {
                Debug.Log(index);
                BackLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
            
        }
        
    }

    

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

            if (button.activeInHierarchy == false)
            {
                button.SetActive(true);

            }
        }
    }

    void BackLine()
    {
        if(index >= 1)
        {
            index--;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }

    }
}
