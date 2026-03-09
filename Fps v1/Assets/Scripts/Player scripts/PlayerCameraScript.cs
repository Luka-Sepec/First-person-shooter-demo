using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject verticalPivot;
    public GameObject weaponManager;
    public InputHandler input;

    public float mouseSensitivity = 15f;
    public float xRotation;
    public float yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = input.lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = input.lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        yRotation += mouseX;

        player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        verticalPivot.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    public void SetSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }
}
