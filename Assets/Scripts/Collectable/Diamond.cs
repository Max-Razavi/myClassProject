using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(BlackHole.instance != null)
        {
            BlackHole.instance.collectableCounts++;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            if (BlackHole.instance != null)
            {
                BlackHole.instance.DecrementCollectable();
            }
        }
    }
}
