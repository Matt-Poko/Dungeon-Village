using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string scenario;
    public string yesSuccess;
    public string yesFail;
    public string no;
    public int threshold;
    public bool oneUse;
    public string building;
    public bool success;
    public int[] stats = new int[8]; // 0food, 1 material 2military 3morality success 4 food 5material 6military 7morality fail
}
