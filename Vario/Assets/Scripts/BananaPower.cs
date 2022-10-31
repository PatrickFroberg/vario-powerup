using System.Collections;
using UnityEngine;

public class BananaPower : MonoBehaviour
{
    public float PowerMultiplier = 1.5f;
    public float PowerDuration = 5f;
    public GameObject CollectEffect;

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
        PlayerSkinManager.Instance.ChangeSkin(PlayerSkinManager.Instance.JumpSkin);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.JumpPower *= PowerMultiplier;

        Debug.Log("BANANA COLLECTED");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //Power last for x sec
        yield return new WaitForSeconds(PowerDuration);

        //Back to normal
        stats.JumpPower /= PowerMultiplier;

        PlayerSkinManager.Instance.ChangeSkin(PlayerSkinManager.Instance.DefaultSkin);

        Destroy(gameObject);
    }
}
