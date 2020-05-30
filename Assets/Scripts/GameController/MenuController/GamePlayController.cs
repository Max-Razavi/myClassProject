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
    private Button resumeGameButton;
    
    [SerializeField]
    private Text pauseText;
    public Player _player;
    public GameObject _Backgroundsound;
    public bool soundOn;
    

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
    public void PlayerDiedScene()
    {
        pauseText.text = "Game Over";
        pausePanel.SetActive(true);
        resumeGameButton.onClick.RemoveAllListeners();
        resumeGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0;
    }
    public void PlayerWinScene()
    {
        pauseText.text = "You Win!";
        pausePanel.SetActive(true);
        resumeGameButton.onClick.RemoveAllListeners();
        resumeGameButton.onClick.AddListener(() => NextLevel());
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
        SceneManager.LoadScene("levelScene1");
    }
    public void ScoreMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ScoreMenu");
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("levelScene2");
    }
    public void Sound()
    {
        if (soundOn == true)
        {
            _Backgroundsound.GetComponent<AudioSource>().mute = true;
            soundOn = false;
        }
         else if (soundOn ==false)
        {
            _Backgroundsound.GetComponent<AudioSource>().mute = false;
            soundOn = true;
        }
        
    }
}
