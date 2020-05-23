using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    private Animator _handAnimation;
    private 


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _handAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _handAnimation.SetTrigger("HandAnimation");
    }
    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
    public void Hit(bool dizzy)
    {
        _anim.SetBool("Dizzy", true);
    }
    public void Die()
    {
        _anim.SetTrigger("Death");
        
    }
}
