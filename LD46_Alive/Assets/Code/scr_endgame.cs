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
    [SerializeField] Button tryagain;
    string currentScene;

	FMOD.Studio.EventInstance Win;
	FMOD.Studio.EventInstance Lose;
	// Start is called before the first frame update
	void Start()
    {
        tryagain.onClick.AddListener(TryAgainClick);
        currentScene = SceneManager.GetActiveScene().name;
        messaging();
		Win = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Win");
		Lose = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Lose");
		if (lost == false)
		{
			Win.start();
		}
		else
		{
			Lose.start();
		}

		Time.timeScale = 0.00001f;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryAgainClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }

    public void GoToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

	void messaging()
	{
		if (lost == false)
		{
			title.text = "Congratulations!";
			content.text = "You kept the little planet alive! It should be fine to leave for another 30 solar rotations or so.";
		}
		else
		{ 
				 Lose.start();
	    }
    }
}
