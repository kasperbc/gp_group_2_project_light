using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpStar : CollectibleItem
{
   
    public float flyingDuration = 5f; // Duration of flying power-up in seconds
    private PlayerMovement player;

    protected override void OnItemCollected()

    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        // Enable flying mode
        player.isFlying = true;
        StartCoroutine(DisableFlyingAfterDelay());
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }


    private IEnumerator DisableFlyingAfterDelay()
    {
        yield return new WaitForSeconds(flyingDuration);

        // Disable flying mode after the specified duration
        player.isFlying = false;
    }

}
