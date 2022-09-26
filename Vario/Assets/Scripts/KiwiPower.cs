using System.Collections;
using UnityEngine;

public class KiwiPower : MonoBehaviour
{
    public float PowerMultiplier = 1.5f;
    public float PowerDuration = 5f;
    public GameObject CollecEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(Collect(collision));
    }

    private IEnumerator Collect(Collider2D player)
    {
        //Boom
        Instantiate(CollecEffect, transform.position, transform.rotation);

        //PowerUp
        PlayerSkinManager.Instance.ChangeSkin(PlayerSkinManager.Instance.RunSkin);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.RunSpeed *= PowerMultiplier;

        Debug.Log("KIWI COLLECTED");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //Power last for x sec
        yield return new WaitForSeconds(PowerDuration);

        //Back to normal
        stats.RunSpeed /= PowerMultiplier;

        PlayerSkinManager.Instance.ChangeSkin(PlayerSkinManager.Instance.DefaultSkin);

        Destroy(gameObject);
    }
}
