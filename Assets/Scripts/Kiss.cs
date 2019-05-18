using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiss : MonoBehaviour
{
    private bool inArea;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp("q") && inArea)
        {
            anim.SetTrigger("kiss");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inArea = false;
        }
    }
}
