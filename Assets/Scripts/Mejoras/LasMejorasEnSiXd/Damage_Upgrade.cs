using UnityEngine;

public class Damage_Upgrade : Upgrade
{
    public override string description()
    {
        return "A�ade 2 puntos de da�o";
    }

    public override void Upg()
    {
        Object.FindObjectOfType<Stats>().AddDamage(2);
    }
}
