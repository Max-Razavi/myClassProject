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

    [SerializeField]
    protected float delayTime;
    [SerializeField]
    protected float destroyTime;
    [SerializeField]
    protected float gravityScale;
    [SerializeField]
    protected float dalayfalling;

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
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine("ResetFallRoutine");
            Destroy(this.gameObject, destroyTime);
            StartCoroutine(ResetDestroy());
            //Debug.Log("i do 1");
        }
    }
    IEnumerator ResetFallRoutine()
    {
        yield return new WaitForSeconds(dalayfalling);
        //_rigidbody2D.WakeUp();
        this._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this._rigidbody2D.gravityScale = gravityScale;

    }
    IEnumerator ResetDestroy()
    {
        yield return new WaitForSeconds(delayTime);
        _destroy = true;

    }
    void SpawnRock()
    {
        //Vector2 rockPosition = new Vector2(transform.position.x, transform.position.y);
        this._rigidbody2D.bodyType = RigidbodyType2D.Static;
        this._rigidbody2D.gravityScale = 0.0f;
        //Instantiate(_rockObject, _posObject.transform.position, Quaternion.identity);
    }
    
}
