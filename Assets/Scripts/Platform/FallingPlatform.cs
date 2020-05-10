using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    protected GameObject _rockObject;

    [SerializeField]
    protected GameObject _posObject;

    private bool _destroy = false;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_destroy == true)
        {
            SpawnRock();
            _destroy = false;
            Debug.Log("i do 2");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(ResetJumpRoutine());
            Destroy(this.gameObject, 17.5f);
            StartCoroutine(ResetDestroy());
            Debug.Log("i do 1");
        }
    }
    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        //_rigidbody2D.WakeUp();
        this._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this._rigidbody2D.gravityScale = 2.0f;

    }
    IEnumerator ResetDestroy()
    {
        yield return new WaitForSeconds(17.0f);
        _destroy = true;

    }
    void SpawnRock()
    {
        //Vector2 rockPosition = new Vector2(transform.position.x, transform.position.y);
        this._rigidbody2D.bodyType = RigidbodyType2D.Static;
        this._rigidbody2D.gravityScale = 0.0f;
        Instantiate(_rockObject, _posObject.transform.position, Quaternion.identity);
    }
    
}
