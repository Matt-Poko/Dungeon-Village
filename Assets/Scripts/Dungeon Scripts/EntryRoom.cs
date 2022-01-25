using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryRoom : MonoBehaviour
{
    public Deck newGame;
    public Deck available;
    void Start()
    {
        List<Card> transfer = new List<Card>();
        if(Manager.day == 1)
        {
            transfer.AddRange(newGame.playerDeck);
            available.playerDeck = transfer;
            GameObject.Find("FreeCard1").SetActive(true);
            GameObject.Find("FreeCard2").SetActive(true);
            GameObject.Find("FreeCard3").SetActive(true);
        }
        else
        {
            GameObject.Find("FreeCard1").SetActive(false);
            GameObject.Find("FreeCard2").SetActive(false);
            GameObject.Find("FreeCard3").SetActive(false);
        }
    }
}