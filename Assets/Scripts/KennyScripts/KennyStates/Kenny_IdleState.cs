using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenny_IdleState : KennyState
{
    Animator anim;
    KennyMovement kenny;
    public override void OnEnter(KennyMachine machine)
    {
        if (!anim)
        {
            anim = machine.GetComponent<Animator>();
            kenny = Object.FindObjectOfType<KennyMovement>();
        }
        anim.SetBool("isIdle", true);
    }

    public override void OnUpdate(KennyMachine machine)
    {
        if (!kenny.stay || kenny.chase)
        {
            machine.SetState(machine.RunState);
            return;
        }
    }

    public override void OnExit(KennyMachine machine)
    {
        anim.SetBool("isIdle", false);
    }
}
