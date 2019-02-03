using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogController : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameController.enableDialog();
    }

}
