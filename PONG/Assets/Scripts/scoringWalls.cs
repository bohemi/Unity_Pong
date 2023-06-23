using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoringWalls : MonoBehaviour
{
    // Audios
    [SerializeField] private AudioClip audioClipBatHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            Sound.instance.wallSound(audioClipBatHit);

            string wallName = transform.name;
            GameManager.score(wallName);
            collision.gameObject.SendMessage("RestartPong", 1.0f, SendMessageOptions.DontRequireReceiver);
        }
    }
}
