using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    private Transform warpPoint;
    private Transform player;
    public string connection;
    public string warpTo;

    private void Start()
    {
        warpPoint = this.transform.Find("WarpPoint");
        player = GameObject.FindWithTag("Player").transform;

        if (GameManager.instance.connection == connection)
        {
            player.position = warpPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.connection = connection;
            SceneManager.LoadScene(warpTo);
        }
    }
}
