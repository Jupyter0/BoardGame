using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<List<GameObject>> board;

    [SerializeField] GameObject tiles;
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject dice;

    [SerializeField] Material player1Mat;
    [SerializeField] Material player2Mat;
    [SerializeField] Material player3Mat;
    [SerializeField] Material player4Mat;

    public string player1Name;
    public string player2Name;
    public string player3Name;
    public string player4Name;

    public Color player1Color;
    public Color player2Color;
    public Color player3Color;
    public Color player4Color;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    private int currentTurn;

    private List<GameObject> playerList = new();

    public List<Tile> tileList = new();

    private List<Material> playerMatList = new();

    private int diceRolled = 0;

    public void InstantiatePlayer(int id, Color color, string name)
    {
        GameObject player = Instantiate(playerModel, new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0));
        PlayerModel playerScript = player.GetComponent<PlayerModel>();
        player.transform.localScale = (Vector3.one)/5  ;
        playerMatList[id].color = color;
        player.GetComponent<MeshRenderer>().material = playerMatList[id];
        playerScript.name = name;
        playerScript.SetID(id);
        playerScript.SetLocation(0);
        playerScript.UpdatePos();

        playerList.Add(player);
    }

    public void DeletePlayer(int id)
    {
        foreach (GameObject player in playerList)
        {
            if (player.GetComponent<PlayerModel>().GetID() == id) {
                Destroy(player);
            }
        }
    }

    public void RollDice()
    {
        GameObject diceObject = Instantiate(dice, new Vector3(0, 5, 0), new Quaternion(
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f)
        ));

        diceObject.GetComponent<RollDice>().Roll();
    }

    public GameObject GetCurrentTurn()
    {
        return playerList[currentTurn];
    }

    public void Turn()
    {
        RollDice();
        RollDice();
    }

    public void DiceDone()
    {
        diceRolled++;

        if (diceRolled == 2)
        {
            diceRolled = 0;
            FinishTurn();
        }
    }

    public void FinishTurn()
    {
        currentTurn++;

        if (currentTurn >= playerList.Count)
        {
            currentTurn = 0;
        }

        Turn();
    }

    private void Start()
    {
        Array Tiles = tiles.GetComponentsInChildren<Tile>();

        foreach (Tile tile in Tiles)
        {
            tileList.Add(tile);
        }

        playerMatList.Add(player1Mat);
        playerMatList.Add(player2Mat);
        playerMatList.Add(player3Mat);
        playerMatList.Add(player4Mat);

        currentTurn = 0;

        InstantiatePlayer(0, player1Color, player1Name);
        InstantiatePlayer(1, player2Color, player2Name);
        InstantiatePlayer(2, player3Color, player3Name);
        InstantiatePlayer(3, player4Color, player4Name);

        Turn();
    }
}