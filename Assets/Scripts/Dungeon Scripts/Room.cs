using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public LootTable lootAll;
    public List<GameObject> currentLootTable;
    public GameObject lootD;
    void Awake()
    {
        BuildTable();
    }
    public void LootChance()
    {
        
        int threshold = Random.Range(0, 100);
        int lootSpawn = Random.Range(0, 100);
        Vector3 moved = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        if (lootSpawn >= threshold)
        {
            if (currentLootTable.Count == 0)
            {
                Instantiate(lootD, moved, Quaternion.identity);
            }
            else
            {
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
}
