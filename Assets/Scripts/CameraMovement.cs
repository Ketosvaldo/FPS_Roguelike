using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    public GameObject[] WeaponsModels;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw(xAxis) * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw(yAxis) * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void DeactivateAllModels()
    {
        for(int i = 0; i < WeaponsModels.Length; i++)
        {
            WeaponsModels[i].gameObject.SetActive(false);
        }
    }

    public void ActivateWeapon(int index)
    {
        WeaponsModels[index].SetActive(true);
    }
}
