using System.Collections;
using UnityEngine;

public class KiwiPower : MonoBehaviour
{
    public float PowerMultiplier = 1.5f;
    public GameObject CollecEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Collect(collision);
    }

    private void Collect(Collider2D player)
    {
        Instantiate(CollecEffect, transform.position, transform.rotation);

        PlayerSkinManager.Instance.ChangeSkin(PlayerSkinManager.Instance.RunSkin);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.RunSpeed *= PowerMultiplier;

        Debug.Log("KIWI COLLECTED");

        Destroy(gameObject);
    }
}
