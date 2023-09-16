using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void StartAgain()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
