using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyBehavior : MonoBehaviour
{
    public GameObject CollecEffect;
    public Text WinnerText;

    private void Start()
    {
        WinnerText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Instantiate(CollecEffect, transform.position, transform.rotation);
            collision.gameObject.GetComponent<PlayerController>().enabled = false;

            WinnerText.enabled = true;
        }
    }
}
