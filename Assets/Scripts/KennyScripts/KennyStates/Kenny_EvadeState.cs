using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenny_EvadeState : KennyState
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
        anim.SetBool("isEvade", true);
    }

    public override void OnExit(KennyMachine machine)
    {
        anim.SetBool("isEvade", false);
    }

    public override void OnUpdate(KennyMachine machine)
    {
        if (!kenny.evade)
            machine.SetState(machine.RunState);
    }
}
