using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public GameObject player;
    
    public void SlowMo()
    {
        Time.timeScale = 0.4f;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<BetterJump>().enabled = false;
        player.GetComponent<Dash>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        //wait for 5 seconds and then resume normal time
        StartCoroutine(Resume());
    }

    IEnumerator Resume()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1f;
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<BetterJump>().enabled = true;
        player.GetComponent<Dash>().enabled = false;
        player.GetComponent<Dash>().ResetDashCount();
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
