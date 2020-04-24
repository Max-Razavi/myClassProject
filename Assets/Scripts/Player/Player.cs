using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour,IDamageable
{    


    private Rigidbody2D _rigid;
    [SerializeField]
    private int _health=3;
    [SerializeField]
    private float _speed = 22.0f;
    [SerializeField]
    private float _jumpForce = 40.0f;
    public bool _grounded = false;
    private bool _resetJump = false;
    
    [SerializeField]
    private LayerMask _groondLayer;

    
    private PlayerAnimation _playeranim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _handArcSprite;
    

    private GameObject _ArcObject;

    protected bool isDead = false;

    public int Health { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playeranim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _handArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _ArcObject = GameObject.FindGameObjectWithTag("HandArc");
        Health = this._health;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            Movement();

            if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
            {
                _playeranim.Attack();
            }
        }
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
        //Debug.DrawRay(transform.position, Vector2.down*5.0f, Color.green);
        if (hitInfo.collider != null)
        {
            //Debug.Log("Hit: " + hitInfo.collider.name);
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
            _handArcSprite.flipX = false;
            _handArcSprite.flipY = false;

            Vector3 newPose = _handArcSprite.transform.localPosition;
            newPose.x = 1.01f;
            _handArcSprite.transform.localPosition = newPose;
            _ArcObject.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _handArcSprite.flipX = true;
           

            Vector3 newPos = _ArcObject.transform.localPosition;
            
            
            newPos.x = 0.25f;
            
            _ArcObject.transform.localPosition = newPos;
            //change z for handArc when flip
            _ArcObject.transform.localRotation = Quaternion.Euler(0, 0, 45);
           
        }
    
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if (isDead == true)
        {
            _playeranim.Die();
            return;
        }

        Health--;
        _playeranim.Hit();


        if (Health < 1)
        {
            isDead = true;
            _playeranim.Die();
            Destroy(this.gameObject, 7.0f);
        }
    }
}
