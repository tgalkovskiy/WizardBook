using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour
{
    public int NumberScene;
    public void Load()
    {
        SceneManager.LoadScene(NumberScene);
    }
}
