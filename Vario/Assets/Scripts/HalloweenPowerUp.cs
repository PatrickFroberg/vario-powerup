using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalloweenPowerUp : MonoBehaviour
{
    public float PowerDuration = 10f;
    public GameObject CollectEffect;
    public GameObject Hat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(Collect(collision));
    }

    private IEnumerator Collect(Collider2D player)
    {
        //Boom
        Instantiate(CollectEffect, transform.position, transform.rotation);

        //PowerUp
        PlayerStats stats = player.GetComponent<PlayerStats>();

        Hat.GetComponent<SpriteRenderer>().enabled = true;
        stats.IsWitch = true;

        Debug.Log("Pumpkin COLLECTED");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //Power last for x sec
        yield return new WaitForSeconds(PowerDuration);

        //Back to normal
        stats.IsWitch = false;
        Hat.GetComponent<SpriteRenderer>().enabled = false;

        Destroy(gameObject);
    }
}