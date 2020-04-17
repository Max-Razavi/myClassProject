using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _jumpForce = 40.0f;
    public bool _grounded = false;
    private bool _resetJump = false;
    
    [SerializeField]
    private LayerMask _groondLayer;

    [SerializeField]
    private float _speed = 22.0f;
    private PlayerAnimation _playeranim;
    private SpriteRenderer _playerSprite;




    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playeranim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();        

    }
    void Movement()
    {
        //move
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }



        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()==true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce); 
            StartCoroutine(ResetJumpRoutine());
            _playeranim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playeranim.Move(move);
    }
    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 5.0f, _groondLayer.value);
        Debug.DrawRay(transform.position, Vector2.down*5.0f, Color.green);
        if (hitInfo.collider != null)
        {
            Debug.Log("Hit: " + hitInfo.collider.name);
            if (_resetJump == false)
            {
                _playeranim.Jump(false);
                return true;
            }            
        }
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
