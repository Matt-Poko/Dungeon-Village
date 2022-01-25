using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Wallet playerWallet;
    public Deck deck;
    public Card welcome1;
    public Card welcome2;
    public Card welcome3;
    public BoolVal[] buildings;
    public BoolVal[] saved;
    void Start()
    {
        playerWallet.amount = 20;
        deck.playerDeck.Clear();
        deck.playerDeck.Add(welcome1);
        deck.playerDeck.Add(welcome2);
        deck.playerDeck.Add(welcome3);
    }

  public void transition()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].val = false;
        }
        for (int i = 0; i < saved.Length; i++)
        {
            saved[i].val = false;
        }
        SceneManager.LoadScene("Village");
        
    }
}
