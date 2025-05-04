using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : BaseCharacter
{
    // [Fields]
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private float _RunningSpeed = 5f;
    private float _jumpHeight = 1f;
    private float _jumpDuration = 0.5f;
    private float _jumpTimer = 0f;
    private float _jumpHeightRunning = 1.5f;
    private float _jumpDurationRunning = 0.7f;
    private float _jumpBufferTime = 0.1f;    
    private float _jumpBufferTimer = 0f;
    private float _coyoteTime = 0.1f;
    private float _coyoteTimer = 0f;

    private bool isRunning = false;
    private bool isJumping = false;
    private bool pendingJump = false;
    private bool isOnGround = false; 

    private Vector3 startPosition;
    // ------------------------------------------------
    // [Lifecycle]
    private void Start()
    {
        InitCharacter("player");
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Jump(); 
        Movement();
    }

    // ------------------------------------------------
    // [Methods]

    public override void Movement()
    {
        base.Movement();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        _animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        _animator.SetFloat("vertical", Mathf.Abs(vertical));

        _rigidBody.velocity = direction * Speed;

        FlipDirection();
        Run();
    }

    public void FlipDirection()
    {
        if (_rigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = _RunningSpeed;
            isRunning = true;
        }
        else
        {
            Speed = 3f;
            isRunning = false;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpBufferTimer = _jumpBufferTime;
        }

        if (isOnGround)
        {
            _coyoteTimer = _coyoteTime;
        }
        else
        {
            _coyoteTimer -= Time.deltaTime;
        }

        if (_jumpBufferTimer > 0f)
        {
            _jumpBufferTimer -= Time.deltaTime;
        }

        if (_jumpBufferTimer > 0f && _coyoteTimer > 0f && !isJumping)
        {
            ReadyForJump();
            _jumpBufferTimer = 0f;
        }

        if (isJumping)
        {
            _jumpTimer += Time.deltaTime;
            float normalizedTime = _jumpTimer / _jumpDuration;

            if (normalizedTime >= 1f)
            {
                normalizedTime = 1f;
                isJumping = false;
                transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            }

            float verticalOffset = Mathf.Sin(normalizedTime * Mathf.PI) * _jumpHeight;
            transform.position = startPosition + new Vector3(0, verticalOffset, 0);
        }
    }

    public void ReadyForJump()
    {
        isJumping = true;
        _jumpTimer = 0f;
        startPosition = transform.position;

        float verticalOffset = Mathf.Sin(0f * Mathf.PI) * _jumpHeight;
        transform.position = startPosition + new Vector3(0, verticalOffset, 0);
    }
}
