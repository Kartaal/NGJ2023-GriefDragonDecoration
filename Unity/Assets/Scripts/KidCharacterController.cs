using UnityEngine;
using ECM.Controllers;
using Rewired;

public class KidCharacterController : BaseCharacterController
{
    public int playerId = 0;

    private Rewired.Player _player;
    private Animator _animator;

    private Vector3 lastPosition;

    public override void Awake()
    {
        base.Awake();
        _player = ReInput.players.GetPlayer(playerId);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        lastPosition  = transform.position;
    }
    
    protected override void HandleInput()
    {
        moveDirection = new Vector3
        {
            x = _player.GetAxisRaw("Horizontal"),
            y = 0.0f,
            z = _player.GetAxisRaw("Vertical")
        };

        //jump = _player.GetButton("Jump");

        crouch = _player.GetButton("Crouch");
    }
    
    private float isMoving;

    public override void Update()
    {
        base.Update();
        isMoving = (lastPosition - transform.position).normalized.sqrMagnitude;
        
        lastPosition = transform.position;
    }

    protected override void Animate()
    {
        animator.SetBool("Crouch", crouch);
        animator.SetFloat("Walk", isMoving);
    }
}
