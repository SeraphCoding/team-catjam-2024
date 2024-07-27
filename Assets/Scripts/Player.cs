using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float interactionRadius = 2f;
    public bool freezePlayer = false;
    
    private PlayerControls _playerControls;
    private Vector2 _movement;
    private Rigidbody2D _body;
    private Animator _anim;
    private Interactable _interactable;
    private static readonly int X = Animator.StringToHash("X");
    private static readonly int Y = Animator.StringToHash("Y");

    private void Start()
    {
        StopAnimation();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerControls.Interaction.Interact.started += Interact;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        Interactables();

        if (freezePlayer) return;
        PlayerInput();
    }

    private void Interact(InputAction.CallbackContext _)
    {
        _interactable?.Interact();
    }

    private void Interactables()
    {
        float closestDist = float.PositiveInfinity;
        Interactable closest = null;
        // Might cause performance issues if there are many interactables in the specified radius.
        foreach (Collider2D overlappingCollider in Physics2D.OverlapCircleAll(transform.position, interactionRadius)) {
            Interactable i = overlappingCollider.GetComponent<Interactable>();

            if (!i || !i.isInteractable) continue;

            float dist = (i.transform.position - transform.position).sqrMagnitude;
            if (dist < closestDist) {
                closest = i;
                closestDist = dist;
            }
        }

        if (closest == _interactable) return;

        if (_interactable) _interactable.UnHover();

        _interactable = closest;

        if (_interactable) _interactable.Hover();
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
            _anim.SetFloat(X, _movement.x);
            _anim.SetFloat(Y, _movement.y);
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
