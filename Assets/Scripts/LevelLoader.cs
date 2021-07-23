using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

   public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    
    }
   public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }

   public void LoadPreviousScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;
        if (previousSceneIndex<0)
        {
            previousSceneIndex = 0;

        }
        SceneManager.LoadScene(previousSceneIndex);

    }

    public void LoadInstructionsMenu()
    {
        SceneManager.LoadScene("Instructions");
    
    }
}
