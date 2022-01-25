using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public LootTable lootAll;
    public List<GameObject> currentLootTable;
    public GameObject lootD;
    private CagedNPC cage;
    void Awake()
    {
        BuildTable();
    }
    public void LootChance()
    {
        
        int threshold = Random.Range(0, 100);
        int lootSpawn = Random.Range(0, 100);
        if(tag == "Special")
        {
            lootSpawn = 1000;
        }
        Vector3 moved = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        if (lootSpawn >= threshold)
        {
            if (currentLootTable.Count == 0)
            {
                Instantiate(lootD, moved, Quaternion.identity);
            }
            else
            {
                if(currentLootTable[0].tag == "Cage")
                {
                    cage = currentLootTable[0].GetComponent<CagedNPC>();
                    checkFree(cage);
                }
                Instantiate(currentLootTable[0], moved, Quaternion.identity);
                currentLootTable.Remove(currentLootTable[0]);
            }
        }
    }
    public void BuildTable()
    {
        for (int i = 0; i < lootAll.loot.Count; i++)
        {
            int random = Random.Range(0, lootAll.loot.Count);
            currentLootTable.Add(lootAll.loot[random]);

        }
        LootChance();
        
    }
    public void checkFree(CagedNPC x)
    {
        if (x.saved.val)
        {
            currentLootTable.Remove(currentLootTable[0]);
            LootChance();
        }
    }
}
