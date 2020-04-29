using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonsterAttacker : Enemy,IDamageable
{

    public GameObject bulletPrefabe;

    

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health--;
        //anim.SetTrigger("Hit");
        //isHit = true;
        //anim.SetBool("InCombat", true);


        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 5.0f);
        }
    
    }
    public override void Movement()
    {
        
    }
    public void Attack()
    {
        
        Instantiate(bulletPrefabe, transform.position, Quaternion.identity);
        //transform.Translate(transform.right * 9 * Time.deltaTime);
    }
}
