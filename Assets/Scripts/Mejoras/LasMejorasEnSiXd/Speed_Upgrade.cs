using UnityEngine;

public class Speed_Upgrade : Upgrade
{
    public override string description()
    {
        return "Obten 2 puntos de velocidad";
    }

    public override void Upg()
    {
        Debug.Log("Hola");
        Movement move = Object.FindObjectOfType<Movement>();
        move.AddSpeed(2);
        Object.FindObjectOfType<GameManager>().SpdUpd(move.GetSpeed());
    }
}