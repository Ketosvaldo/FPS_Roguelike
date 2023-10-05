using UnityEngine;
using TMPro;

public class UpgradeGenerator : MonoBehaviour
{
    public GameObject UpgradeUI;
    public TextMeshProUGUI[] description;

    Upgrade[] allUpgrades = { 
        new DD_HL_Upgrade(),
        new Damage_Upgrade(),
        new Life_Upgrade(),
        new Speed_Upgrade()
    };

    int[] randomNum = new int[2];
    private void Start()
    {
        UpgradeUI.SetActive(true);
        randomNum[0] = Random.Range(0, allUpgrades.Length);
        randomNum[1] = Random.Range(0, allUpgrades.Length);
        while (randomNum[0] == randomNum[1])
        {
            randomNum[1] = Random.Range(0, allUpgrades.Length);
        }
        description[0].text = allUpgrades[randomNum[0]].description();
        description[1].text = allUpgrades[randomNum[2]].description();
    }

    public void Upgrade1()
    {
        allUpgrades[0].Upg();
    }

    public void Upgrade2()
    {
        allUpgrades[1].Upg();
    }
}