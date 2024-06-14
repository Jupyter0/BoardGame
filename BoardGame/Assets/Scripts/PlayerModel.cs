using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private GameManager gameManager;

    private int id;
    private Color color;
    private int currentLocation;
    private string objectName;

    public int GetID()
    {
        return id;
    }

    public int GetLocation()
    {
        return currentLocation;
    }

    public string GetObjectName()
    {
        return objectName;
    }
    public void SetID(int ID)
    {
        id = ID;
    }

    public void SetLocation(int location)
    {
        currentLocation = location;
    }

    public void SetObjectName(string objectname)
    {
        objectName = objectname;
    }

    [SerializeField] Vector3 offset = new Vector3(0, 0.25f, 0);

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void MoveBy(int dist)
    {
        currentLocation += dist;

        if (currentLocation > 43)
        {
            currentLocation -= 44;
        }

        UpdatePos();
    }

    public void UpdatePos()
    {
        gameObject.name = objectName;
        transform.position = gameManager.tileList[currentLocation].SlotList[id].transform.position + offset;
    }
}
