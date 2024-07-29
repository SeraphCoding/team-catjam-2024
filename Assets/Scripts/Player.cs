using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float interactionRadius = 2f;

    public bool FreezePlayer
    {
        get => _freezePlayer;
        set
        {
            _freezePlayer = value;
            if (value) {
                StopAnimation();
                _movement = Vector2.zero;
            }
            else {
                StartAnimation();
            }
            //Debug.Log("Player Frozen: " + value);
        }
    }
    
    [SerializeField] private CapsuleCollider2D horizontalCollider;
    [SerializeField] private CapsuleCollider2D verticalCollider;

    private bool _freezePlayer = false;
    // GET YO BELL TACO (Player Controls) from here. Don't instantiate your own.
    public static PlayerControls _playerControls;
    private Vector2 _movement;
    private Rigidbody2D _body;
    private Animator _anim;
    private Interactable _interactable;
    /// <summary>
    /// When the player is interacting with an interactable that can be rotated, it will freeze the player and transfer
    /// the AD input to the interactable to decide for a rotation direction.
    /// </summary>
    private bool _isRotatingInteractable;
    private static readonly int X = Animator.StringToHash("X");
    private static readonly int Y = Animator.StringToHash("Y");

    public Interactable Interactable => _interactable;
    
    private void Start()
    {
        StopAnimation();
    }

    private void Awake()
    {
        if (_playerControls != null) _playerControls.Dispose();
        _playerControls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerControls.Interaction.Interact.started += Interact;
        _playerControls.Interaction.Rotate.started += Rotate;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        Interactables();
        PlayerInput();
    }

    private void Interact(InputAction.CallbackContext _)
    {
        _interactable?.Interact();
    }
    
    private void Rotate(InputAction.CallbackContext _)
    {
        Debug.Log("Rotate");
        if (_interactable && _interactable.isRotatable)
            _interactable?.Rotate();
        FreezePlayer = _interactable?.IsBeingRotated ?? false;
        Debug.Log("Player Interactible Rotation "+ _interactable?.IsBeingRotated);
        Debug.Log("Player Frozen "+FreezePlayer);
    }

    private void Interactables()
    {
        float closestDist = float.PositiveInfinity;
        Interactable closest = null;
        // Might cause performance issues if there are many interactables in the specified radius.
        foreach (Collider2D overlappingCollider in Physics2D.OverlapCircleAll(transform.position, interactionRadius, 1 << 8)) {
            Interactable i = overlappingCollider.GetComponent<Interactable>();

            if (!i || (!i.IsInteractable && !i.isRotatable)) continue;

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
        UpdateOrientation();
    }

    private void PlayerInput()
    {
        if (FreezePlayer) return;
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();

        if (_movement.magnitude == 0) {
            if (_anim.speed != 0) StopAnimation();
        } else {
            if (_anim.speed == 0) StartAnimation();
            _anim.SetFloat(X, _movement.x);
            _anim.SetFloat(Y, _movement.y);
        }
    }

    private void UpdateOrientation()
    {
        float horizontalOrientation = Mathf.Abs(_anim.GetFloat(X)) ;
        float verticalOrientation = Mathf.Abs(_anim.GetFloat(Y));
        if (horizontalOrientation > verticalOrientation) {
            horizontalCollider.enabled = true;
            verticalCollider.enabled = false;
        } else {
            horizontalCollider.enabled = false;
            verticalCollider.enabled = true;
        }
        
    }

    private void Move()
    {
        _body.MovePosition(_body.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void StopAnimation()
    {
        _anim.speed = 0;
        // If the animation is not set to the first frame, the cat will stand on just some of its legs when the player is frozen.
        _anim.Play(0, 0, 0); // reset the animation
    }

    private void StartAnimation()
    {
        _anim.speed = 1;
    }
}
