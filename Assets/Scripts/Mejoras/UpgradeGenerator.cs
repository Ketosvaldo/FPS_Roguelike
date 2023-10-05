using UnityEngine;
using TMPro;

public class UpgradeGenerator : MonoBehaviour
{
    public GameObject UpgradeUI;
    public TextMeshProUGUI[] description;
    public GameManager manager;

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
        description[1].text = allUpgrades[randomNum[1]].description();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        manager = FindObjectOfType<GameManager>();
    }

    public void Upgrade1()
    {
        allUpgrades[randomNum[0]].Upg();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpgradeUI.SetActive(false);
        FindObjectOfType<Movement>().gameObject.transform.position = new Vector3(-62, 0, 98);
        manager.ResetEnemyCounter();
        gameObject.SetActive(false);
    }

    public void Upgrade2()
    {
        allUpgrades[randomNum[1]].Upg();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpgradeUI.SetActive(false);
        FindObjectOfType<Movement>().gameObject.transform.position = new Vector3(-62, 0, 98);
        manager.ResetEnemyCounter();
        gameObject.SetActive(false);
    }
}