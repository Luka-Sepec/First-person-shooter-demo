using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    public CrosshairManager crosshairManager;
    public InputHandler input;
    private float scrollValue;
    private int currentWeaponIndex = 0;
    void Start()
    {
        SelectWeapon(currentWeaponIndex);
    }

    
    void Update()
    {
        scrollValue = input.scrollValue;

        if (scrollValue > 0f)
        {
            currentWeaponIndex = currentWeaponIndex + 1 <= weapons.Length - 1 ? currentWeaponIndex + 1 : 0;
            SelectWeapon(currentWeaponIndex);
        }

        if (scrollValue < 0f)
        {
            currentWeaponIndex = currentWeaponIndex - 1 >= 0 ? currentWeaponIndex - 1 : weapons.Length - 1;
            SelectWeapon(currentWeaponIndex);
        }
    }

    public void SelectWeapon(int weaponIndex)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == weaponIndex);
            crosshairManager.crosshairs[i].SetActive(i == weaponIndex);

            if (i == weaponIndex)
            {
                var raise = transform.GetComponentInChildren<WeaponRaise>();
                if (raise != null) raise.RaiseWeapon();
            }
        }
    }
}
