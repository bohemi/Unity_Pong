using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject ballObj;

    public static int playerScore1 = 0;
    public static int playerScore2 = 0;

    public GUISkin layout;

    // Start is called before the first frame update
    void Start()
    {
        ballObj = GameObject.FindGameObjectWithTag("Ball");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public static void score(string sideWalls)
    {
        if (sideWalls == "RightWall")
        {
            playerScore1++;
        }
        else
            playerScore2++;
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        //Score icons
        GUI.Label(new Rect(Screen.width / 2 - 190 - 12, 20, 100, 100), "" + playerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 190 + 12, 20, 100, 100), "" + playerScore2);

        //Restart button
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 40), "RESTART"))
        {
            playerScore1 = 0;
            playerScore2 = 0;

            ballObj.SendMessage("RestartPong", 0.5f, SendMessageOptions.DontRequireReceiver);
        }

        if (playerScore1 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WON");

            ballObj.SendMessage("ResetBall", null, SendMessageOptions.DontRequireReceiver);
        }
        else if (playerScore2 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WON");

            ballObj.SendMessage("ResetBall", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
