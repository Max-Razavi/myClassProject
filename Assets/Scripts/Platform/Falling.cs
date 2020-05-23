using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    //public GameObject _ice;
    public Rigidbody2D _rigidbody2D;
    [SerializeField]
    protected float gravityScale;
    [SerializeField]
    protected float DestroyItemTime = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        //_ice = GameObject.FindGameObjectWithTag("Ice");
        //_rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody2D.gravityScale = gravityScale;
            //Destroy(collision.gameObject);
            Destroy(gameObject, DestroyItemTime);
        }
        //else if (collision.gameObject.tag == "Ground")
        //{
        //    gameObject.SetActive(false);
        //    Destroy(gameObject);
        //}

    }
}
