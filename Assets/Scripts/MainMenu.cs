using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {

    }

   public void PlayBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("Exit pressed");
    }
}
