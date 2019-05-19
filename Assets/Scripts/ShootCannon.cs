using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    public GameObject ball;
    public float inital;
    public float rate;
    public float speed;

    void Start()
    {
        InvokeRepeating("Fire", inital, rate);
    }

    void Update()
    {
         Quaternion rotation = Quaternion.LookRotation(PlayerController.instance.transform.position - transform.position, transform.TransformDirection(Vector3.up));
         transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void Fire()
    {
        Cannonball newBall = Instantiate(ball, transform.position, transform.rotation).GetComponent<Cannonball>();
        newBall.speed = speed;

    }
}
