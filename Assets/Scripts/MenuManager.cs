using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //	Load main menu
    public void backToMain()
    {
        SceneManager.LoadScene(2);
    }

    //	Start Level 1 of the game.
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    //	Got To Achievements menu.
    public void enemyTypes()
    {
        SceneManager.LoadScene(1);
    }

    //	Exit the game.
    public void quitGame()
    {
        Application.Quit();
    }
}
