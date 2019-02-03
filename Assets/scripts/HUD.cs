using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        
        Transform inventoryPanel = transform.Find("Inventory");
        

        foreach (Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            StartCoroutine(showInventoryWhenPick(1.5f));
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

    private IEnumerator showInventoryWhenPick(float waitTime)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
