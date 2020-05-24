using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonster : Enemy, IDamageable
{

    public GameObject bulletPrefabe;

    //public Transform player;
    //public Rigidbody2D bullet;

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
    //public override void Update()
    //{

    //}

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
            this.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject, 3.0f);
        }
    }

    public void Attack()
    {
        //Instantiate(bulletPrefabe, transform.position, transform.rotation);
        ////var fire = Instantiate(bulletPrefabe, player.position, player.rotation);
        ////bullet.AddForce(player.up * 6);

    }


}
