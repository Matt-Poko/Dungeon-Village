using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagedNPC : MonoBehaviour
{
    public BoolVal saved;
    public Card reward;
    private Player tempP;
    public void Awake()
    {
        tempP = GameObject.Find("Player").GetComponent<Player>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            /*if (saved.val)
            {
                tempP.myWallet.amount++;
                gameObject.SetActive(false);
            }*/
            if (tempP.keys.Count > 0)
            {
                    tempP.myDeck.playerDeck.Add(reward);
                    tempP.keys.RemoveAt(0);
                    saved.val = true;
                    gameObject.SetActive(false);
                
            }
        }
    }
}
