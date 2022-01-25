using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church : MonoBehaviour
{
    public BoolVal built;
    public bool isClickable;

    public void AddMorality()
    {
        if (isClickable)
        {
            Manager.morality += 5;
            isClickable = false;
        }
    }
}
