using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitmentCenter : MonoBehaviour
{
    public BoolVal built;
    public bool isClickable;

    public void AddMilitary()
    {
        if (isClickable)
        {
            Manager.military += 5;
            isClickable = false;
        }
    }
}
