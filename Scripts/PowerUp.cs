using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        // Debug.Log("Power up picked up");
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // apply effect to the player
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //wait x amount of seconds
        yield return new WaitForSeconds(duration);
        stats.health /= multiplier;

        Destroy(gameObject);
    }
}
