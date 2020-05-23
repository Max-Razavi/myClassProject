using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelayFall = 2.0f;
    public float respawnDelayDie = 1.5f;
    public Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnFall()
    {
        StartCoroutine("RespawnCoroutine");
    }
    //making delay for respawn just for playerFall
    public IEnumerator RespawnCoroutine()
    {
        _player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelayFall);
        _player.transform.position = _player.respawnPoint;
        _player.gameObject.SetActive(true);
        
    }
    public void RespawnDie()
    {
        StartCoroutine("RespawnCoroutine1");
    }
    //making delay for respawn just for playerDie
    public IEnumerator RespawnCoroutine1()
    {
        yield return new WaitForSeconds(respawnDelayDie);
        
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
