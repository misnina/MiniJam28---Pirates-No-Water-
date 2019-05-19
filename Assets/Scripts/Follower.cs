using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Transform target;
    private SpriteRenderer sr;

    public bool following = false;
    public float speed;
    private float xDirection = 0;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (following) {
            Follow();
        }
    }

    private void Follow()
    {
        //FLIP
        if (PlayerController.instance.moveX < 0.0f)
        {
            sr.flipX = false;
            xDirection = +1f;
        } 
        else if(PlayerController.instance.moveX > 0.0f)
        {
            sr.flipX = true;
            xDirection = -1;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x + xDirection, target.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
