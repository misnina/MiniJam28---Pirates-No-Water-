using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiss : MonoBehaviour
{
    private bool inArea;
    private Animator anim;
    private Follower followerScript;
    private GameObject hearty;

    private void Start()
    {
        anim = GetComponent<Animator>();
        followerScript = GetComponent<Follower>();
        hearty = transform.Find("Hearty").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyUp("q") && inArea)
        {
            StartCoroutine("KissThenFollow");
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

    IEnumerator KissThenFollow()
    {
        anim.SetTrigger("kiss");
        yield return new WaitForSeconds(1);
        hearty.SetActive(false);
        followerScript.following = true;
        GameManager.instance.hasFollower = true;
    }
}
