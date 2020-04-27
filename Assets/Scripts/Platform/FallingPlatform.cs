using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ResetJumpRoutine());
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(ResetJumpRoutine());
        }
    }
    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        //_rigidbody2D.WakeUp();
        this._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this._rigidbody2D.gravityScale = 2.0f;

    }
}
