using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public Inventory inventory;
    private const string INSTRUCTION_PHRASE = "Busca las pistas del crimen. Cerca de ellas hay partículas amarillas en suspensión. Una vez encontradas entra de nuevo en comisaría." +
        "Evita que los aliados del pez gordo te capturen";

    private void OnControllerColliderHit(ControllerColliderHit hit){
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();

        if(item != null)
            inventory.AddItem(item);
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "InitialDialog")
        {
            StartCoroutine(showInstructions(10f));
            other.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private IEnumerator showInstructions(float waitTime)
{
    GameObject.FindGameObjectWithTag("ResponseContainer").GetComponent<Text>().text = INSTRUCTION_PHRASE;
    yield return new WaitForSeconds(waitTime);
    GameObject.FindGameObjectWithTag("ResponseContainer").GetComponent<Text>().text = "";
}

}
