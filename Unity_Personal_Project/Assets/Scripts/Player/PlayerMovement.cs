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

    private bool isRunning = false;

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
}
