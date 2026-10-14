using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuTransition : MonoBehaviour
{
    public void ChangeScene() 
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
