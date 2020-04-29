using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonsterPatEvent : MonoBehaviour
{
    private redMonster _redMonsPat;

    private void Start()
    {
        _redMonsPat = transform.parent.GetComponent<redMonster>();
    }
    public void Fire()
    {
        //Debug.Log("Spider shoud Fire ");
        _redMonsPat.Attack();
    }
}
