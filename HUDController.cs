using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public Text ammoText;
    public GameObject crosshair;

    public void SetHealth(float current, float max)
    {
        if (healthBar) healthBar.value = current / max;
        if (healthText) healthText.text = $"{Mathf.CeilToInt(current)} / {Mathf.CeilToInt(max)}";
    }

    public void SetAmmo(int current, int max)
    {
        if (ammoText) ammoText.text = $"{current} / {max}";
    }

    public void SetCrosshairActive(bool active)
    {
        if (crosshair) crosshair.SetActive(active);
    }
}
