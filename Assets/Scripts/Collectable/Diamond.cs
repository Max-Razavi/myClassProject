using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip _CoinSound;
    
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if(BlackHole.instance != null)
        {
            BlackHole.instance.collectableCounts++;
        }
        _audioSource = GetComponent<AudioSource>();
        //_audioSource.clip = _CoinSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _audioSource.Play();
            //StartCoroutine("HideGameObject");
            Destroy(gameObject, 0.26f);
            //gameObject.SetActive(false);
            if (BlackHole.instance != null)
            {
                BlackHole.instance.DecrementCollectable();
            }
        }
    }
    //IEnumerator HideGameObject()
    //{
    //    yield return new WaitForSeconds(0.26f);
    //    Destroy(gameObject);
    //}
}
