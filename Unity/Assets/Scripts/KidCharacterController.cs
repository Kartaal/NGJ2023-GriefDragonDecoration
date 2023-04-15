using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using Rewired;
using UnityEditor.Build.Content;

public class KidCharacterController : BaseCharacterController
{
    public int playerId = 0;

    private Player _player;
    
    public override void Awake()
    {
        base.Awake();
        _player = ReInput.players.GetPlayer(playerId);
    }
    
    protected override void HandleInput()
    {
        moveDirection = new Vector3
        {
            x = _player.GetAxisRaw("Horizontal"),
            y = 0.0f,
            z = _player.GetAxisRaw("Vertical")
        };

        jump = _player.GetButton("Jump");

        crouch = _player.GetButton("Crouch");
    }
}
