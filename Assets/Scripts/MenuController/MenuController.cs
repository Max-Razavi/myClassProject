using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("levelScene");
    }
    public void RecordsMenu()
    {
        SceneManager.LoadScene("ScoreMenu");
    }
}
