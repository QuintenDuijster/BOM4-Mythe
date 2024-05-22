using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PrompLoader : MonoBehaviour
{
    [SerializeField] public string SceneToLoad;
    [SerializeField] internal GameObject Canvas;
    [SerializeField] public GameObject promptBackGround;
    [SerializeField] public Sprite imgToLoad; 
    [SerializeField] public SceneLoader loader;
    
    private void OnTriggerEnter(Collider other)
    {
        ChangePrompt();
        enablePrompt();
    }

    private void OnTriggerExit(Collider other)
    {
        disablePrompt();
    }
    internal void Start()
    {
        disablePrompt();
    }



    public void disablePrompt()
    {
        
        Canvas.SetActive(false); 
    }
    public void enablePrompt()
    {       
        Canvas.SetActive(true);
       
    }
    public void ChangePrompt()
    {
        Image image = promptBackGround.GetComponent<Image>();
        image.sprite = imgToLoad;
        loader.Scene = SceneToLoad; 
       
      

    }

  

}
