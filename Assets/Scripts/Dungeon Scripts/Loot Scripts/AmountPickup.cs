using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountPickup : MonoBehaviour
{
    public int amount;
    private Card cardToAdd;
    public Deck availableCards;
    private Player tempP;
    public void Awake()
    {
        tempP = GameObject.Find("Player").GetComponent<Player>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        { if (this.tag == "Coin")
            {
                tempP.myWallet.amount += amount;
                gameObject.SetActive(false);
            }
        else if (this.tag == "Oil")
            {
                float oil = amount;
                tempP.lantern += oil;
                gameObject.SetActive(false);
            } 
        else if(tag == "CardPickup")
            {
                Deck temp = tempP.myDeck;
                chooseCardLoot();
                if (availableCards.playerDeck.Count != 0)
                {
                    temp.playerDeck.Add(cardToAdd);
                }
                gameObject.SetActive(false);
            }
        else if (tag == "Key")
            {
                tempP.keys.Add("Key");
                gameObject.SetActive(false);
            }
        }
    }
    public void chooseCardLoot()
    {
        if (availableCards.playerDeck.Count != 0)
        {
            int index = Random.Range(0, availableCards.playerDeck.Count);
            cardToAdd = availableCards.playerDeck[index];
            availableCards.playerDeck.Remove(availableCards.playerDeck[index]);
        }
        else
        {
            tempP.myWallet.amount += 1;
        }
    }

}
