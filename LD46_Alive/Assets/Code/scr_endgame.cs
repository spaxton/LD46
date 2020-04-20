using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_endgame : MonoBehaviour
{
    public bool lost = true;
    [SerializeField] Text title;
    [SerializeField] Text content;

    // Start is called before the first frame update
    void Start()
    {
        messaging();
        Time.timeScale = 0.00001f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void messaging()
    {
        if(lost == false)
        {
            title.text = "Congratulations!";
            content.text = "You kept the little planet alive! It should be fine to leave for another 30 solar rotations or so.";
        }
    }
}
