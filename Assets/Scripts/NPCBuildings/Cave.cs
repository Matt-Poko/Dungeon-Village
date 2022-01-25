using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public BoolVal built;
    public bool isClickable;

    public void AddMaterial()
    {
        if (isClickable)
        {
            Manager.material += 5;
            isClickable = false;
        }
    }
}
