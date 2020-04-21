using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadLvl2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void LoadLvl3()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
