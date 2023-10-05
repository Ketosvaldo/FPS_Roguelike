using UnityEngine;

public class DD_HL_Upgrade : Upgrade
{
    public override string description()
    {
        return "Tu da�o aumenta al doble, pero tu vida m�xima se reduce a la mitad";
    }

    public override void Upg()
    {
        Stats props = Object.FindObjectOfType<Stats>();
        props.AddDamage(props.GetDamage());
        props.SetHealth(props.GetHealth() / 2);
    }
}