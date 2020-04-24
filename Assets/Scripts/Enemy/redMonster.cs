﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonster : Enemy, IDamageable
{

    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        //Debug.Log("redMonster :: Damage()");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat",true);


        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 5.0f);
        }
    }


}
