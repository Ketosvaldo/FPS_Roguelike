using UnityEngine;

public class Damage_Upgrade : Upgrade
{
    public override string description()
    {
        return "A�ade 2 puntos de da�o";
    }

    public override void Upg()
    {
        Stats props = Object.FindObjectOfType<Stats>();
        props.AddDamage(2);
        Object.FindObjectOfType<GameManager>().DmgUpd(props.GetDamage());
    }
}
