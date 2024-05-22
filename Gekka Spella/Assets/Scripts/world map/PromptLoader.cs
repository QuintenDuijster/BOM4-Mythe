using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PromprLoader : MonoBehaviour
{
    [SerializeField] public string SceneToLoad; 
    [SerializeField] internal GameObject Canvas;
    public SceneLoader loader;
  

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
        loader.Scene = SceneToLoad;
        Debug.Log(loader.Scene);
    }

  

}
