using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Library : MonoBehaviour
{
    public BoolVal built;
    public bool isClickable;

    public void transition()
    {
        SceneManager.LoadScene("Library");
    }
}
