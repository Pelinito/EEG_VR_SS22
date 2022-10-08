using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject howToMenu;

    // Start is called before the first frame update
    void Start()
    {
         MainMenuButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        mainMenu.SetActive(false);
    }

    public void HowToButton()
    {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        mainMenu.SetActive(true);
        howToMenu.SetActive(false);
    }
}
