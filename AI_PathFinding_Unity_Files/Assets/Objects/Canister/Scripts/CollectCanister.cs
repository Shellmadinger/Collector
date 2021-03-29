using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCanister : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5f); //Destroy object after time passes
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.tag == "Officer") //Destroy when hit by Officer
        {
            Destroy(gameObject);
        }

    }
}
