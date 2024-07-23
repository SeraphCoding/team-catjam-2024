using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    private PlayerControls _playerControls;
    private Vector2 _movement;
    private Rigidbody2D _body;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }
    

    private void FixedUpdate() 
    {
        Move();
    }

    private void PlayerInput()
    {
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        _body.MovePosition(_body.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
