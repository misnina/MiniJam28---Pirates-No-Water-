using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        PlayerController.instance.canMove = false;
        GameManager.instance.hasFollower = false;
        PlayerController.instance.anim.SetTrigger("sleep");
        yield return new WaitForSeconds(2f);
        Destroy(PlayerController.instance.gameObject);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
