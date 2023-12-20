using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadAnim : MonoBehaviour
{
    private const string IsJumpPad = "IsJumpPad";

    [SerializeField] private Animator anim;
    [SerializeField] private JumpPadInteraction jumpPad;

    private void Start() 
    {
        jumpPad.OnJumpPad += jumpPad_OnJumpPad;
    }

    private void jumpPad_OnJumpPad(object sender, EventArgs e)
    {
        anim.SetTrigger(IsJumpPad);
    }
}
