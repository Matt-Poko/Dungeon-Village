using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private RoomTemplates templates;
    public int doorNeeded;
    // 1 top
    // 2 bottom
    // 3 right
    // 4 left
    private int rand;
    private int lootChance;
    private GameObject sprite;
    public bool triggered;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        triggered = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            triggered = true;
        }
        if (other.CompareTag("Wall"))
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            triggered = true;
        }
        if (doorNeeded == 1 && !triggered)
        {
            rand = Random.Range(0, templates.topRooms.Length);
            sprite = templates.topRooms[rand];
            if (other.CompareTag("Player"))
            {
                Vector3 moved = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5.5f);
                Instantiate(sprite, moved, templates.topRooms[rand].transform.rotation);
            
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                triggered = true;
            }
        }
        else if (doorNeeded == 2 && !triggered)
        {
            rand = Random.Range(0, templates.bottomRooms.Length);
            sprite = templates.bottomRooms[rand];
            if (other.CompareTag("Player"))
            {
                Vector3 moved = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+5.5f);
                Instantiate(sprite, moved, templates.bottomRooms[rand].transform.rotation);
                //me.transform.position = new Vector3(me.transform.position.x, me.transform.position.y + 5.5f);
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                triggered = true;
            }
        }
        else if (doorNeeded == 3 && !triggered)
        {
            rand = Random.Range(0, templates.rightRooms.Length);
            sprite = templates.rightRooms[rand];
            if (other.CompareTag("Player"))
            {
                Vector3 moved = new Vector3(this.gameObject.transform.position.x - 5.5f, this.gameObject.transform.position.y);
                Instantiate(sprite, moved, templates.rightRooms[rand].transform.rotation);
                //me.transform.position = new Vector3(me.transform.position.x - 5.5f, me.transform.position.y);
                gameObject.GetComponent<Collider2D>().enabled = false;
                triggered = true;
            }
        }
        else if (doorNeeded == 4 && !triggered)
        {
            rand = Random.Range(0, templates.leftRooms.Length);
            sprite = templates.leftRooms[rand];
            if (other.CompareTag("Player"))
            {
                Vector3 moved = new Vector3(gameObject.transform.position.x + 5.5f, gameObject.transform.position.y);
                Instantiate(sprite, moved, templates.leftRooms[rand].transform.rotation);
                //me.transform.position = new Vector3(me.transform.position.x + 5.5f, me.transform.position.y);
                gameObject.GetComponent<Collider2D>().enabled = false;
                triggered = true;
            }
        }
        
    }
}
