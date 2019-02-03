using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public bool open = false;
    public float leftDoorOpenAngle = 45f;
    public float leftDoorCloseAngle = 0f;
    public float rightDoorOpenAngle = 45f;
    public float rightDoorCloseAngle = 0f;
    public float smooth = 2f;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public AudioClip openDoorFX;
    public AudioClip closeDoorFX;

    public AudioSource source
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if(other.gameObject.tag == "Player")
        {
            open = true;
            source.PlayOneShot(openDoorFX);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.gameObject.tag == "Player")
        {
            open = false;
            source.PlayOneShot(closeDoorFX);
        }
    }
    */
    public void switchDoorState()
    {
        open = !open;

        if(source.clip == closeDoorFX)
            source.PlayOneShot(openDoorFX);
        else
            source.PlayOneShot(closeDoorFX);

    }


    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, leftDoorOpenAngle, 0);
            leftDoor.transform.localRotation = Quaternion.Slerp(leftDoor.transform.localRotation, targetRotation, smooth * Time.deltaTime);

            targetRotation = Quaternion.Euler(0, rightDoorOpenAngle, 0);
            rightDoor.transform.localRotation = Quaternion.Slerp(rightDoor.transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }

        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, leftDoorCloseAngle, 0);
            leftDoor.transform.localRotation = Quaternion.Slerp(leftDoor.transform.localRotation, targetRotation, smooth * Time.deltaTime);

            targetRotation = Quaternion.Euler(0, rightDoorCloseAngle, 0);
            rightDoor.transform.localRotation = Quaternion.Slerp(rightDoor.transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
    }
}
