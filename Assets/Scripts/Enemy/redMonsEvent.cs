using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonsEvent : MonoBehaviour
{
    private redMonsterAttacker _redMonsAttacker;

    private void Start()
    {
        _redMonsAttacker = transform.parent.GetComponent<redMonsterAttacker>();
    }
    public void Fire()
    {
        //Debug.Log("Spider shoud Fire ");
        _redMonsAttacker.Attack();
    }
}
