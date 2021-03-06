﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string location;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.instance.hasFollower)
        {
            Debug.Log("Completed level");
            GameManager.instance.hasFollower = false;
            GameManager.instance.connection = "ship-spawn";
            SceneManager.LoadScene(location);
        }
    }
}
