using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() //that will load scene with +1 index to mainmenu scene in build settings hierarchy
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GoToMainMenu() //that will load scene with +1 index to mainmenu scene in build settings hierarchy
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() //that will close the window
    {
        Debug.Log("Quit!"); //for tasting that it workes in unity
        Application.Quit();
    }

    //private string gameSceneName = "Scene1"; // Name of the game scene

    public void ContinueGame()
    {
        // You can implement your game state loading logic here.
        // For example, load the saved game state before transitioning to the game scene.
        // You should have a system in place to manage saved game data.

        // Load the game scene where you left off.
        //SceneManager.LoadScene(gameSceneName);
    }
}
