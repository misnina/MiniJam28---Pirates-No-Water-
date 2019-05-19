using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = PlayerController.instance.transform.position - transform.position;
        rb.AddForce(direction * speed);
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
