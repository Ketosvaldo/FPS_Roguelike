using UnityEngine;

public class Life_Upgrade : Upgrade
{
    public override string description()
    {
        return "Cura por completo tu vida y aumenta en 20 puntos";
    }

    public override void Upg()
    {
        Object.FindObjectOfType<Stats>().HealthUp(20);
    }
}