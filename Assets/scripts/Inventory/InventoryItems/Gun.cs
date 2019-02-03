using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Chair";
        }
    }

    public Sprite _Image = null;

    public ParticleSystem takeFX;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        takeFX.Play();
        gameObject.SetActive(false);
    }

}
