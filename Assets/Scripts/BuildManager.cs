using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Farm
    public Farm farm;
    public GameObject f;
    //Mine
    public Cave cave;
    public GameObject ca;
    //Church
    public Church church;
    public GameObject ch;
    //RecruitmentCenter
    public RecruitmentCenter recruitmentCenter;
    public GameObject rc;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.Find("Church");
        rc = GameObject.Find("RC");
        f = GameObject.Find("Farm"); //Farm Object
        ca = GameObject.Find("Cave");
        checker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Builder(Card c)
    {
        if (c.oneUse)
        {
            if (c.building == "Farm")
            {
                f.SetActive(true);
                farm.built.val = true;
                farm.isClickable = true;


            }
            else if (c.building == "Cave")
            {
                ca.SetActive(true);
                cave.built.val = true;
                cave.isClickable = true;
            }
            else if (c.building == "Church")
            {
                ch.SetActive(true);
                church.built.val = true;
                church.isClickable = true;
            }
            else if (c.building == "Recruiting Center")
            {
                rc.SetActive(true);
                recruitmentCenter.built.val = true;
                recruitmentCenter.isClickable = true;
            }
            
        }

    }
    public void checker()
    {
        farm = f.GetComponent<Farm>();
        cave = ca.GetComponent<Cave>();
        church = ch.GetComponent<Church>();
        recruitmentCenter = rc.GetComponent<RecruitmentCenter>();
        if (farm.built.val == true)
        {
            f.SetActive(true);
            farm.isClickable = true;

        }
        else
        {
            f.SetActive(false);
        }
        if (cave.built.val == true)
        {
            ca.SetActive(true);
            cave.isClickable = true;

        }
        else
        {
            ca.SetActive(false);
        }
        if (church.built.val == true)
        {
            ch.SetActive(true);
            church.isClickable = true;

        }
        else
        {
            ch.SetActive(false);
        }
        if (recruitmentCenter.built.val == true)
        {
            rc.SetActive(true);
            recruitmentCenter.isClickable = true;

        }
        else
        {
            rc.SetActive(false);
        }
    }
}
