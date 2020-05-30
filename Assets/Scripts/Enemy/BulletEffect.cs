using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    [SerializeField]
    private float _bulletTime;
    [SerializeField]
    private float _destroybulletTime;

    private void Start()
    {
        Destroy(this.gameObject, _destroybulletTime);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * _bulletTime * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
