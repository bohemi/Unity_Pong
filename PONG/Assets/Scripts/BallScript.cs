using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Audios
    [SerializeField] private AudioClip audioClipBatHit;
    [SerializeField] private AudioClip audioClipUpDownWallHit;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Invoke("initBall", 1.8f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("upDownWalls"))
        {
            Sound.instance.upDownWallsSound(audioClipUpDownWallHit);
        }

        if (collision.collider.CompareTag("paddles"))
        {
            Sound.instance.batSound(audioClipBatHit);

            Vector2 velocity;

            velocity.x = rigidBody.velocity.x;
            velocity.y = rigidBody.velocity.y / Random.Range(1, 2); // bit of different y Velocity every hit

            rigidBody.velocity = velocity;
        }
    }

    // Throw at random direction at the beginning and resets
    public void initBall()
    {
        int random = Random.Range(0, 5);
        if (random < 2)
        {
            rigidBody.AddForce(new Vector2(30, -25));
        }
        else
        {
            rigidBody.AddForce(new Vector2(-25, -20));
        }
    }

    public void ResetBall()
    {
        rigidBody.velocity = new Vector2(0, 0);
        transform.position = Vector2.zero;
    }

    public void RestartPong()
    {
        ResetBall();
        Invoke("initBall", 1);
    }
}
