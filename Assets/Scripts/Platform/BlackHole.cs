using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;

public class BlackHole : MonoBehaviour
{
    public static BlackHole instance;
    public GameObject _gameObject;
    private BoxCollider2D _boxcollider2D;
    [HideInInspector]
    public int collectableCounts;

    //public GamePlayController _gamePalyController;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstanse();
        _boxcollider2D = GetComponent<BoxCollider2D>();
        //GamePlayController _game = new GamePlayController();
    }

    void MakeInstanse()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectable()
    {
        collectableCounts--;
        if(collectableCounts == 0)
        {
            StartCoroutine("OpenHole");
        }
    }
    IEnumerator OpenHole()
    {
        yield return new WaitForSeconds(0.7f);
        _gameObject.SetActive(true);
        this.GetComponent<BoxCollider2D>().enabled = true;
        //_boxcollider2D.enabled = true;
        _boxcollider2D.isTrigger = true;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerWinScene();
            GameObject.Find("Player").SetActive(false);
            //Debug.Log("finish");
            //_gamePalyController.PlayerWinScene();
            //_pausepanel.SetActive(true);
            //_player.SetActive(false);
        }
    }


}
