using UnityEngine;

public class Speed_Upgrade : Upgrade
{
    public override string description()
    {
        return "Obten 2 puntos de velocidad";
    }

    public override void Upg()
    {
        Object.FindObjectOfType<Movement>().AddSpeed(2.0f);
    }
}