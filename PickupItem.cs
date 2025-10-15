using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemID;
    public AudioClip pickupSfx;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var inv = other.GetComponent<InventorySystem>();
        if (inv != null)
        {
            bool added = inv.AddItem(itemID);
            if (added)
            {
                if (AudioManager.Instance) AudioManager.Instance.PlaySFX(pickupSfx);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Inventory full!");
            }
        }
    }
}
