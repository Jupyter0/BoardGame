using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string player1Name = "Player 1";
    public string player2Name = "Player 2";
    public string player3Name = "Player 3";
    public string player4Name = "Player 4";

    public Color player1Color = Color.blue;
    public Color player2Color = Color.yellow;
    public Color player3Color = Color.green;
    public Color player4Color = Color.red;

    public void StartGame()
    {
        var sceneLoad = SceneManager.LoadSceneAsync("Board");

        sceneLoad.completed += (x) =>
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            gameManager.player1Name = player1Name;
            gameManager.player2Name = player2Name;
            gameManager.player3Name = player3Name;
            gameManager.player4Name = player4Name;

            gameManager.player1Color = player1Color;
            gameManager.player2Color = player2Color;
            gameManager.player3Color = player3Color;
            gameManager.player4Color = player4Color;
        };
    }
}