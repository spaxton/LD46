using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scr_timer : MonoBehaviour
{
    [SerializeField] Text timer_text;
    [SerializeField] float start_time;
    [SerializeField] GameObject enderPrefab;
    float current_time;
    bool ended = false;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        current_time = start_time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((current_time <= 0) && (ended == false))
        {
            GameObject endgame = Instantiate(enderPrefab, new Vector3(Screen.width/2, Screen.height/2, 0), new Quaternion(0, 0, 0, 0));
            ended = true;
            endgame.transform.parent = canvas.transform;
            endgame.GetComponent<scr_endgame>().lost = false;
        }

        //float t = Time.time - start_time;
        current_time -= 1 * Time.deltaTime;

        string minutes = ((int)current_time / 60).ToString();
        string seconds = (current_time % 60).ToString("f1");
        timer_text.text = minutes + ":" + seconds;
        //timer_text.text = current_time.ToString();

        
    }
}
