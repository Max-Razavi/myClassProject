using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFalling : MonoBehaviour
{
    [SerializeField]
    protected float destroyTime = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
