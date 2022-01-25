using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //Disaster and day info
    public static int day;
    public Text currentDay;
    //Player info
    public Deck deck;
    public Wallet playerWallet;
    public List<Card> tempDeck;
    public Text coinsToSpend;
    //First card
    public Text scenario1;
    Card firstCard;
    //Second card
    private Text scenario2;
    Card secondCard;
    //Third card
    private Text scenario3;
    Card thirdCard;
    //Stat info
    public Text morselT;
    public Text materialT;
    public Text militaryT;
    public Text moralityT;
    public static int morsel;
    public static int material;
    public static int military;
    public static int morality;
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

    void Awake()
    {
        ch = GameObject.Find("Church");
        rc = GameObject.Find("RC");
        f = GameObject.Find("Farm"); //Farm Object
        ca = GameObject.Find("Cave");
        checker();

        day += 1;
        currentDay = GameObject.Find("Current Day").GetComponent<Text>();
        tempDeck.AddRange(deck.playerDeck);
        coinsToSpend = GameObject.Find("CoinsToSpend").GetComponent<Text>();
        morselT = GameObject.Find("Morsel").GetComponent<Text>();
        materialT = GameObject.Find("Material").GetComponent<Text>();
        militaryT = GameObject.Find("Military").GetComponent<Text>();
        moralityT = GameObject.Find("Morality").GetComponent<Text>();
        GameObject.Find("Card1").SetActive(true);
        GameObject.Find("Card2").SetActive(true);
        GameObject.Find("Card3").SetActive(true);
        scenario1 = GameObject.Find("Scenario1").GetComponent<Text>();
        scenario2 = GameObject.Find("Scenario2").GetComponent<Text>();
        scenario3 = GameObject.Find("Scenario3").GetComponent<Text>();
    }
    private void Start()
    {
        currentDay.text = "Day: " + day;
        if(day % 10 == 0)
        {
            DisasterStrikes(day);
            if(day == 20)
            {
                endOfDays();
            }
        }
        coinsToSpend.text = "Available coins: " + playerWallet.amount;
        morselT.text = "Morsel: " + morsel;
        materialT.text = "Material: " + material;
        militaryT.text = "Military: " + military;
        moralityT.text = "Morality: " + morality;
        int rand = Random.Range(0, tempDeck.Count);
        firstCard = tempDeck[rand];
        scenario1.text = firstCard.scenario;
        tempDeck.Remove(tempDeck[rand]);
        rand = Random.Range(0, tempDeck.Count);
        secondCard = tempDeck[rand];
        scenario2.text = secondCard.scenario;
        tempDeck.Remove(tempDeck[rand]);
        rand = Random.Range(0, tempDeck.Count);
        thirdCard = tempDeck[rand];
        scenario3.text = thirdCard.scenario;
        tempDeck.Remove(tempDeck[rand]);
    }
    private void Update()
    {
        morselT.text = "Morsel: " + morsel;
        materialT.text = "Material: " + material;
        militaryT.text = "Military: " + military;
        moralityT.text = "Morality: " + morality;
    }
    public void YesAnswer1()
    {
        GameObject.Find("Yes1").GetComponent<Button>().interactable = false;
        GameObject.Find("No1").GetComponent<Button>().interactable = false;
        int rand = Random.Range(1, 6);
        if (rand >= firstCard.threshold)
        {
            if (firstCard.building != "")
                Build(firstCard);
            firstCard.success = true;
            scenario1.text = firstCard.yesSuccess;
        }
        else
        {
            scenario1.text = firstCard.yesFail;
        }
        addStats(firstCard);
        if (firstCard.oneUse)
        deck.playerDeck.Remove(firstCard);
        StartCoroutine(Disappear(GameObject.Find("Card1")));
    }
    public void YesAnswer2()
    {
        GameObject.Find("Yes2").GetComponent<Button>().interactable = false;
        GameObject.Find("No2").GetComponent<Button>().interactable = false;
        int rand = Random.Range(1, 6);
        if (rand >= secondCard.threshold)
        {
            if (secondCard.building != "")
                Build(secondCard);
            secondCard.success = true;
            scenario2.text = secondCard.yesSuccess;
        }
        else
        {
            scenario2.text = secondCard.yesFail;
        }
        addStats(secondCard);
        if (secondCard.oneUse)
            deck.playerDeck.Remove(secondCard);
        StartCoroutine(Disappear(GameObject.Find("Card2")));
    }
    public void YesAnswer3()
    {
        GameObject.Find("Yes3").GetComponent<Button>().interactable = false;
        GameObject.Find("No3").GetComponent<Button>().interactable = false;
        int rand = Random.Range(1, 6);
        if (rand >= thirdCard.threshold)
        {
            if (thirdCard.building != "")
                Build(thirdCard);
            thirdCard.success = true;
            scenario3.text = thirdCard.yesSuccess;
        }
        else
        {
            scenario3.text = thirdCard.yesFail;
        }
        addStats(thirdCard);
        if (thirdCard.oneUse)
            deck.playerDeck.Remove(thirdCard);
        StartCoroutine(Disappear(GameObject.Find("Card3")));
    }
    public void No1()
    {
        GameObject.Find("Yes1").GetComponent<Button>().interactable = false;
        GameObject.Find("No1").GetComponent<Button>().interactable = false;
        scenario1.text = firstCard.no;
        StartCoroutine(Disappear(GameObject.Find("Card1")));
    }
    public void No2()
    {
        GameObject.Find("Yes2").GetComponent<Button>().interactable = false;
        GameObject.Find("No2").GetComponent<Button>().interactable = false;
        scenario2.text = secondCard.no;
        StartCoroutine(Disappear(GameObject.Find("Card2")));
    }
    public void No3()
    {
        GameObject.Find("Yes3").GetComponent<Button>().interactable = false;
        GameObject.Find("No3").GetComponent<Button>().interactable = false;
        scenario3.text = thirdCard.no;
        StartCoroutine(Disappear(GameObject.Find("Card3")));
    }
    IEnumerator Disappear(GameObject x)
    {
        yield return new WaitForSeconds(5f);
        x.SetActive(false);
    }
    public void addStats(Card c)
    {
        if (c.success)
        {
            morsel += c.stats[0];
            material += c.stats[1];
            military += c.stats[2];
            morality += c.stats[3];
            morselT.text = "Morsel: " + morsel;
            materialT.text = "Material: " + material;
            militaryT.text = "Military: " + military;
            moralityT.text = "Morality: " + morality;
        }
        else
        {
            morsel += c.stats[4];
            material += c.stats[5];
            military += c.stats[6];
            morality += c.stats[7];
            morselT.text = "Morsel: " + morsel;
            materialT.text = "Material: " + material;
            militaryT.text = "Military: " + military;
            moralityT.text = "Morality: " + morality;
        }
        if(c.building != "")
        {
            Build(c);
        }
    }
    public void DisasterStrikes(int day)
    {
        int numberOfNegative = 0;
        int max = 15;
        max -= day + 1;
        int f = Random.Range(0, max);
        int mat = Random.Range(0, max);
        int mil = Random.Range(0, max);
        int mor = Random.Range(0, max);
        morsel -= f;
        material -= mat;
        military -= mil;
        morality -= mor;
        if (morsel < 0)
        {
            numberOfNegative += 1;
        }
        if (material < 0)
        {
            numberOfNegative += 1;
        }
        if (military < 0)
        {
            numberOfNegative += 1;
        }
        if (morality < 0)
        {
            numberOfNegative += 1;
        }
        
        StartCoroutine(VillageLost(numberOfNegative));
    }
    IEnumerator VillageLost(int x)
    {
        if(x >= 3)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("GameOver");
        }
        
    }
    public void Build(Card c)
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
            deck.playerDeck.Remove(c);
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
    public void endOfDays()
    {

    }
}
