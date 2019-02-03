using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    private Animator animator;
    private bool open = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("open", true);

            if (!open && GetComponent<AudioSource>() != null)
            {
                open = true;
                GetComponent<AudioSource>().PlayDelayed(0.3f);
            }
        }
            
    }
}
