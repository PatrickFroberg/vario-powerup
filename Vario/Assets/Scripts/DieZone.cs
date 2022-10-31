using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieZone : MonoBehaviour
{
    public GameObject DieEffect;
    public float TimeUntilRestart = 3f;
    public Text DieText;

    private void Start()
    {
        DieText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(Collect(collision));
    }

    private IEnumerator Collect(Collider2D player)
    {
        Instantiate(DieEffect, player.transform.position, player.transform.rotation);

        player.gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        DieText.enabled = true;

        Debug.Log("Dead");

        yield return new WaitForSeconds(TimeUntilRestart);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
