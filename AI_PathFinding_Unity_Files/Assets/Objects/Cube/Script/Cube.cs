using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float deathTime;

    Rigidbody cubeBody;

    private void Start()
    {
        cubeBody = GetComponent<Rigidbody>();
        StartCoroutine(KillSelf());
    }
    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(deathTime); //Destroy object after time passes
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Officer") //if colliding with player or officer...
        {
            Vector3 forceDirection = transform.position - collision.transform.position; //find direction of object

            forceDirection.Normalize(); //Normalize it

            cubeBody.AddForce(forceDirection * 40, ForceMode.Impulse); //Add force
        }
    }
}
