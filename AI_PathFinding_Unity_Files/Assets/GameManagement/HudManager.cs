using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour {
    //Initializing variables
    public Text playerScore;
    public Text hoarderScore;
    string scoreFormat = "0#";
    public int scoreCountPlayer;
    int scoreCountHoarder;

    private void Update()
    {
        UpdateHud();
        WinScreen();
    }

    void UpdateHud()
    {
        //Storing the text for hud
        playerScore.text = "Player: " + scoreCountPlayer.ToString(scoreFormat);
        hoarderScore.text = "Hoarder: " + scoreCountHoarder.ToString(scoreFormat);
    }

    public void IncreasePlayerScore()
    {
        //Increase score if player gets a Sphere.
        scoreCountPlayer++;
        UpdateHud();
    }

    public void IncreaseHoarderScore()
    {
        //Increase hoarder score if they get a Sphere.
        scoreCountHoarder++;
        UpdateHud();
    }

    public void LoseSpheres(int decreaseScore)
    {
        //Reduce player score
        scoreCountPlayer -= decreaseScore;
        UpdateHud();
    }

    void WinScreen()
    {
        if (scoreCountPlayer == 20)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

}
