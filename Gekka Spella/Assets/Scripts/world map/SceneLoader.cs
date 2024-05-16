using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public string Scene = "";
   public void LoadScene()
    {
        SceneManager.LoadScene(Scene);
    }

   
}


