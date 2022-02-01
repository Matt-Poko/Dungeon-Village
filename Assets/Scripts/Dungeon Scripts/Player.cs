using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}


public class Player : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    public Text lanturnLife;
    public float lantern;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public List<string> keys;
    public Deck myDeck;
    public Wallet myWallet;
    public SpriteRenderer receivedItemSprite;


    // Start is called before the first frame update
    void Start()
    {
        lanturnLife = GameObject.Find("LanternLife").GetComponent<Text>();
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        lanturnLife.text = "Lanturn Life: " + (int)lantern;
        lantern -= Time.deltaTime;
        if(lantern <= 0)
        {
            SceneManager.LoadScene("Village");
        }
        if (currentState == PlayerState.interact)
        {
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        MoveCharacter();
        /*if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
            StartCoroutine(AttackCo()); */
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
    /*private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }*/


