using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] RollDice diceScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Center")
        {
            diceScript.SetResult(int.Parse(gameObject.name.Replace("Trigger", "")));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Center")
        {
            diceScript.SetResult(0);
        }
    }
}
