using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public bool freezePlayer = false;
    
    private PlayerControls _playerControls;
    private Vector2 _movement;
    private Rigidbody2D _body;
    private Animator _anim;

    private void Start()
    {
        StopAnimation();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        if (freezePlayer) return;
        PlayerInput();
    }
    

    private void FixedUpdate() 
    {
        Move();
    }

    private void PlayerInput()
    {
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();

        if (_movement.magnitude == 0) {
            if (_anim.speed != 0) StopAnimation();
        } else {
            if (_anim.speed == 0) StartAnimation();
            _anim.SetFloat("X", _movement.x);
            _anim.SetFloat("Y", _movement.y);
        }
    }

    private void Move()
    {
        _body.MovePosition(_body.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void StopAnimation()
    {
        _anim.speed = 0;
        _anim.Play(0, 0, 0); // set animation to first frame
    }

    private void StartAnimation()
    {
        _anim.speed = 1;
    }
}
