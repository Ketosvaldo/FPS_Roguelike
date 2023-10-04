using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenny_RunState : KennyState
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
        anim.SetBool("isPatrol", true);
    }

    public override void OnExit(KennyMachine machine)
    {
        anim.SetBool("isPatrol", false);
    }

    public override void OnUpdate(KennyMachine machine)
    {
        if (kenny.stay)
        {
            machine.SetState(machine.IdleState);
            return;
        }
        if(kenny.attack)
        {
            machine.SetState(machine.AttackState); 
            return;
        }
        if (kenny.evade) 
        {
            machine.SetState(machine.EvadeState);
            return;
        }
    }
}
