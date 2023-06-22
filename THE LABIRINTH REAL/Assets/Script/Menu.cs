using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Ui pages")]
    public GameObject start;
    public GameObject about;

    [Header("button")]
    public Button Play;
    public Button About;
    public Button Exit;

    public List<Button> returnButtons;
    // Start is called before the first frame update
    void Start()
    {
        EnableStart();
        Play.onClick.AddListener(StarGames);
        About.onClick.AddListener(EnableAbout);
        Exit.onClick.AddListener(ExitGame);
        
        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableStart);
        }

    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void StarGames()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Create_with_VR_Starter_Scene");
    }

    public void EnableStart()
    {
        start.SetActive(true);
        about.SetActive(false);
    }

    public void EnableAbout()
    {
        start.SetActive(false);
        about.SetActive(true);
    }

}
