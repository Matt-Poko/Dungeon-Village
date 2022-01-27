using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryRoom : MonoBehaviour
{
    public Deck newGame;
    public Deck available;
    void Start()
    {
        if(Manager.day == 1)
        {
            available.playerDeck.Clear();
            available.playerDeck.AddRange(newGame.playerDeck);
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
        if(Manager.day > 2 && Manager.day < 9)
        {
            GameObject.Find("FreeKey").SetActive(true);
            GameObject.Find("FreeFlask").SetActive(true);
        }
        else
        {
            GameObject.Find("FreeKey").SetActive(false);
            GameObject.Find("FreeFlask").SetActive(false);
        }
    }
}
