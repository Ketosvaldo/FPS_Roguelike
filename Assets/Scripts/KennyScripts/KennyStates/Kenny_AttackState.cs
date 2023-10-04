using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenny_AttackState : KennyState
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
        anim.SetBool("isAttacking", true);
    }

    public override void OnExit(KennyMachine machine)
    {
        anim.SetBool("isAttacking", false);
    }

    public override void OnUpdate(KennyMachine machine)
    {
        if (!kenny.attack)
        {
            machine.SetState(machine.IdleState);
            return;
        }
    }
}
