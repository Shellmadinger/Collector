using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollide : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(8f); //Destroy object after time passes
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) //Destroy sphere when colliding with player and npcs. Score controlled by npcs and player
                                                       //This is mostly so that the sphere doesn't destroy itself when it hits the ground
    {
        if (collision.gameObject.tag == "Hoarder")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Officer")
        {
            Destroy(gameObject);
        }
        
    }
}
