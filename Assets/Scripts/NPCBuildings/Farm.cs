using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public BoolVal built;
    public bool isClickable;

    public void AddMorsel()
    {
        if (isClickable)
        {
            Manager.morsel += 5;
            isClickable = false;
        }
    }
}
