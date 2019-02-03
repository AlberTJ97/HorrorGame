using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class policeDoor : MonoBehaviour
{
    private Inventory inventoryManager;
    private const string DEFAULT_RESPONSE = "Necesitas recoger todos los objetos para resolver el crimen";

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(inventoryManager.getNumberOfSlots() == inventoryManager.getNumberOfItems())
        {
            SceneManager.LoadScene("FinalScene");
        } else {
            StartCoroutine(showGameNotFinisehd(5f));
        }
    }

    private IEnumerator showGameNotFinisehd(float waitTime)
    {
        GameObject.FindGameObjectWithTag("ResponseContainer").GetComponent<Text>().text = DEFAULT_RESPONSE;
        yield return new WaitForSeconds(waitTime);
        GameObject.FindGameObjectWithTag("ResponseContainer").GetComponent<Text>().text = "";
    }
}
