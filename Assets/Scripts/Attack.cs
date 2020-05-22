﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    [SerializeField]
    private float _destroyTime = 2.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            if (_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
        
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
