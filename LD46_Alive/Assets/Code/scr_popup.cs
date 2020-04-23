using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_popup : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text content;
    [SerializeField] Button gotit;
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        gotit.onClick.AddListener(gotItClick);
        currentScene = SceneManager.GetActiveScene().name;
        messaging();
        Time.timeScale = 0.00001f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gotItClick()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }

    void messaging()
    {
        if (currentScene == "Scene1")
        {
            content.text = "This plucky little planet has changed so much! It even has lifeforms, adorable! Uh oh, they may not realize what those FACTORIES are putting in the atmosphere. I should clean up a little.";
        }

        if (currentScene == "Scene2")
        {
            title.text = "So many lifeforms!";
            content.text = "These little things build a LOT! Impressive work. Uh oh, those REACTORS need to cool down or they could do some serious damage. That RADIATION can't be removed until it's contained.";
        }

        if (currentScene == "Scene3")
        {
            title.text = "They keep growing!";
            content.text = "So artistic! So inventive! Maybe they just need a little help to keep the planet habitable, I don't want them to have to leave so soon.";
        }
    }


}
