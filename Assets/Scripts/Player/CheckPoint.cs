using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer changeSpriteRendere;
    public Sprite blackFlag, greenFlag;
    public bool checkPointReached;
    public GameObject _checkPoint;



    // Start is called before the first frame update
    void Start()
    {
        changeSpriteRendere = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            changeSpriteRendere.sprite = greenFlag;
            checkPointReached = true;
            _checkPoint.GetComponent<CapsuleCollider2D>().enabled = false;

        }
    }
}
