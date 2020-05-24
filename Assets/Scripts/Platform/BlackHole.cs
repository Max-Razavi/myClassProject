using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BlackHole : MonoBehaviour
{
    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _player;

    public static BlackHole instance;
    //public Renderer _balckHole;
    public GameObject _gameObject;
    private BoxCollider2D _boxcollider2D;
    [HideInInspector]
    public int collectableCounts;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstanse();
        _boxcollider2D = GetComponent<BoxCollider2D>();
        //_balckHole = GetComponent<Renderer>();
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
        //this._balckHole.enabled=true;
        _boxcollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("finish");
            _winPanel.SetActive(true);
            _player.SetActive(false);
        }
    }


}
