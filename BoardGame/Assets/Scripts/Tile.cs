using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<GameObject> SlotList = new();

    public string tileFunction;


    public int tileNumber;

    private void Awake()
    {
        tileNumber = int.Parse(gameObject.name.Replace("Tile", ""));

        SlotList.Add(transform.Find("Slot1").gameObject);
        SlotList.Add(transform.Find("Slot2").gameObject);
        SlotList.Add(transform.Find("Slot3").gameObject);
        SlotList.Add(transform.Find("Slot4").gameObject);
    }
}
