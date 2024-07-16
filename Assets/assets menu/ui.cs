using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    
    public void LoadGame()
    {
        
        SceneManager.LoadScene("call"); 
        
    }
    public void LoadinGame()
    {

        SceneManager.LoadScene("game");

    }
    public void menu()
    {

        SceneManager.LoadScene("menu");

    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
