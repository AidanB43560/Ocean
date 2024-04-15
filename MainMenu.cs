using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void quitGame(){
        Application.Quit();
    }
    public void GoToHelpMenu(){
        SceneManager.LoadScene("HelpMenu");
    }
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToGame(){
        SceneManager.LoadScene("Game");
    }
    
}
