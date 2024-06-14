using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public int upwardsFacingNumber = 0;
    private bool sendResult = false;
    private float timer = 1.0f;
    public void Roll()
    {
        sendResult = true;
        gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(
            Random.Range(0.0f, 100.0f),
            Random.Range(0.0f, 100.0f),
            Random.Range(0.0f, 100.0f)
        ));
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -0.1f, 0));
    }

    private void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero && sendResult)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                gameManager.GetCurrentTurn().GetComponent<PlayerModel>().MoveBy(upwardsFacingNumber);
                timer = 1.0f;
                sendResult = false;
                Destroy(gameObject);
                gameManager.DiceDone();
            }
        }
    }

    public void SetResult(int num)
    {
        upwardsFacingNumber = num;
    }
}
