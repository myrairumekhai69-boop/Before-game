using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // prefabs or weapon gameobjects (child)
    int currentIndex = 0;

    void Start()
    {
        SetWeapon(currentIndex);
    }

    public void SetWeapon(int index)
    {
        if (weapons == null || weapons.Length == 0) return;
        currentIndex = Mathf.Clamp(index, 0, weapons.Length - 1);
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].SetActive(i == currentIndex);
    }

    public void NextWeapon()
    {
        int next = (currentIndex + 1) % weapons.Length;
        SetWeapon(next);
    }

    public GameObject GetCurrentWeapon()
    {
        if (weapons == null || weapons.Length == 0) return null;
        return weapons[currentIndex];
    }
}
