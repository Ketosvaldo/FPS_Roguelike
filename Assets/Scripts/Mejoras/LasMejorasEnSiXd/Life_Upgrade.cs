using UnityEngine;

public class Life_Upgrade : Upgrade
{
    public override string description()
    {
        return "Cura por completo tu vida y aumenta en 20 puntos";
    }

    public override void Upg()
    {
        Stats props = Object.FindObjectOfType<Stats>();
        props.HealthUp(20);
        Object.FindObjectOfType<GameManager>().LifeUpd(props.GetCurrentHealth(), props.GetHealth());
    }
}