using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void onClick(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

