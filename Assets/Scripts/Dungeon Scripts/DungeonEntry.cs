using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntry : MonoBehaviour
{
    public string sceneToLoad;
    public Wallet playerWallet;
    public void transition()
    {
        if (playerWallet.amount >= 5)
        {
            playerWallet.amount -= 5;
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            int rand = Random.Range(1, 4);
            if(rand == 1)
            {
                Manager.morsel -= 5;
                playerWallet.amount = playerWallet.amount + 5;
            }
            else if(rand == 2)
            {
                Manager.material -= 5;
                playerWallet.amount = playerWallet.amount + 5;
            }
            else if (rand == 3)
            {
                Manager.military -= 5;
                playerWallet.amount = playerWallet.amount + 5;
            }
            else if (rand == 4)
            {
                Manager.morality -= 5;
                playerWallet.amount = playerWallet.amount + 5;
            }
        }
    }
}
