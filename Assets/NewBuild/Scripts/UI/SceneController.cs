
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static AsyncOperation _operation;
    
    public static void LoadScene(int numberScene)
    {
        _operation = SceneManager.LoadSceneAsync(numberScene);
    }
    
}
