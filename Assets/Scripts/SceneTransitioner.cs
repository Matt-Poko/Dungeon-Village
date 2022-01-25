using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitioner : MonoBehaviour
{
    public string sceneToLoad;
    public void transition()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
