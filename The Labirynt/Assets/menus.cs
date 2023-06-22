using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menus : MonoBehaviour
{

  public Button move;
    // Start is called before the first frame update
    void Start()
    {
        move.onClick.AddListener(StarGames);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGames()
    {
        SceneManager.LoadScene("starScrean");
    }
}
