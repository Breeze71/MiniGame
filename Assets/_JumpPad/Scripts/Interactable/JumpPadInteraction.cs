using System;
using UnityEngine;
using V.Core;

public class JumpPadInteraction : InteractableBase
{
    //[SerializeField] private float bounceForce;
    public event EventHandler OnJumpPad;

    public override void Interact()
    {
        OnJumpPad?.Invoke(this, EventArgs.Empty); // Anim

        playerMovement.Jump();
    }
}
