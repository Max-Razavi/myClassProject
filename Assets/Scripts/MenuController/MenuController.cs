using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    

    public void PlayGame()
    {
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("levelScene");
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void RecordsMenu()
    {
        SceneManager.LoadScene("ScoreMenu");
    }
}
