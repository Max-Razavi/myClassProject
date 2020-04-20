using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMonster : Enemy
{

    
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _redMonsterSprite;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _redMonsterSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        
        movement();
    }
    void movement()
    {
        if (_currentTarget == pointB.position)
        {
            _redMonsterSprite.flipX = true;
        }
        else
        {
            _redMonsterSprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("idle");
            

        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("idle");
            

        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        
    }
}
