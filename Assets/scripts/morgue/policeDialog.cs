using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class policeDialog : MonoBehaviour, IPointerEnterHandler
{

    public void Start()
    {
        GameController.showDialog += showDialog;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameController.enableDialog();
    }

    /*
    public void OnPointerExit(PointerEventData eventData)
    {
        GameController.disableDialog();
    }
    */

    private void showDialog()
    {
        GameController.disableInventory();
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
