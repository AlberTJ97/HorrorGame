using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private const int slots = 2;

	private List<IInventoryItem> mItems = new List<IInventoryItem>();

	public event EventHandler<InventoryEventArgs> ItemAdded;
    public AudioSource source {
        get {
            return GetComponent<AudioSource>();
        }
    }
    public AudioClip takeObjectFX;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
    }

    public void AddItem(IInventoryItem item){
        if (mItems.Count < slots){
			Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled){
                collider.enabled = false;
				mItems.Add(item);
				item.OnPickup();
                source.PlayOneShot(takeObjectFX);

                if (ItemAdded != null) { 
                    ItemAdded(this, new InventoryEventArgs(item));
                }
			}
		}
	}

    public int getNumberOfSlots()
    {
        return slots;
    }

    public int getNumberOfItems()
    {
        return mItems.Count;
    }
}
