using UnityEngine;

public class Damage_Upgrade : Upgrade
{
    public override string description()
    {
        return "Añade 2 puntos de daño";
    }

    public override void Upg()
    {
        Object.FindObjectOfType<Stats>().AddDamage(2);
    }
}
