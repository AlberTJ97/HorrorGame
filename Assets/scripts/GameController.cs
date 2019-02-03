using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject dialogs;

    public delegate void pointerEvent();
    public static event pointerEvent showDialog;

    public static event pointerEvent leftDialogBubble;
    public static event pointerEvent rightDialogBubble;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory != null)
            inventory.SetActive(false);

        if(dialogs != null)
            dialogs.SetActive(false);

        /*
        if(SceneManager.GetActiveScene().name == "morgue")
            StartCoroutine(LoadLandScapeScene());
            */
    }

    IEnumerator LoadLandScapeScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Landscape");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("SquareButton") && inventory != null)
        {
            inventory.SetActive(true);
        }

        if (Input.GetButtonUp("SquareButton") && inventory != null)
        {
            inventory.SetActive(false);
        }

        if (dialogs != null && Input.GetButtonDown("LButton") && dialogs.active)
        {
            if(leftDialogBubble != null)
                leftDialogBubble();
        }

        if (dialogs != null && Input.GetButtonDown("RButton") && dialogs.active)
        {
            if(rightDialogBubble != null)
                rightDialogBubble();
        }
    }

    public static void enableDialog()
    {
        if (showDialog != null)
        {
            showDialog();
        }
    }

    public static void disableInventory()
    {
        if(GameObject.FindWithTag("Inventory") != null)
            GameObject.FindWithTag("Inventory").SetActive(false);
    }
}
