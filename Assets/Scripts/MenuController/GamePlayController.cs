using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject WinPanel;
    [SerializeField]
    private Button resumeGameButton;
    [SerializeField]
    private Button menuGameButton;

    [SerializeField]
    private Text pauseText;
    public Player _player;

    private void Update()
    {
        PlayerDied();
    }
    void PlayerDied()
    {
        if (_player.Health < 1)
        {
            StartCoroutine("DiedScene");
        }
        
    }
    void PlayerDiedScene()
    {
        pauseText.text = "Game Over";
        pausePanel.SetActive(true);
        resumeGameButton.onClick.RemoveAllListeners();
        menuGameButton.onClick.RemoveAllListeners();
        resumeGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0;
    }
    IEnumerator DiedScene()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerDiedScene();
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        resumeGameButton.onClick.RemoveAllListeners();
        resumeGameButton.onClick.AddListener(() => ResumeGame());
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("levelScene");
    }
    public void ScoreMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ScoreMenu");
    }
}
