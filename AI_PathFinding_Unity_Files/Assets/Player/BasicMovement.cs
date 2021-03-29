using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    float horiMove;
    float vertMove;
    Rigidbody basicBody;
    public HudManager updateScore;
    public int decreaseScoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        basicBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horiMove = Input.GetAxis("Horizontal");
        vertMove = Input.GetAxis("Vertical");
        if (horiMove > 0)
        {
            basicBody.velocity = new Vector3(horiMove * speed, basicBody.velocity.y, basicBody.velocity.z);

        }

        if (horiMove < 0)
        {
            basicBody.velocity = new Vector3(horiMove * speed, basicBody.velocity.y, basicBody.velocity.z);
        }

        if (vertMove > 0)
        {
            basicBody.velocity = new Vector3(basicBody.velocity.x, basicBody.velocity.y, vertMove * speed);
        }

        if (vertMove < 0)
        {
            basicBody.velocity = new Vector3(basicBody.velocity.x, basicBody.velocity.y, vertMove * speed);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere") // Increase player score when collecting a sphere
        {
            updateScore.IncreasePlayerScore();
        }

        if (collision.gameObject.tag == "Hoarder" || collision.gameObject.tag == "officer") // Lose sphere when colliding with Hoarder or Officer
        {
            updateScore.LoseSpheres(decreaseScoreAmount);
        }
    }
}
