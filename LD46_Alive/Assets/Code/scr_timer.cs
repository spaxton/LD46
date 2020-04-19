using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scr_timer : MonoBehaviour
{
    public Text timer_text;
    float start_time;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - start_time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");
        timer_text.text = minutes + ":" + seconds;
    }
}
