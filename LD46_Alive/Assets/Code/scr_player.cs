using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player : MonoBehaviour
{
    public bool suck_active = false;
    public bool laser_active = false;
    public bool beam_active = false;

    public int hp = 100;
    public Text hp_text;
    public GameObject enderPrefab;
    bool ended = false;

    public Button suckButt;
    public Button laserButt;
    public Button iceButt;

    GameObject ray;

    // Start is called before the first frame update
    void Start()
    {
        ray = this.gameObject.transform.GetChild(0).gameObject;
        suckButt.onClick.AddListener(suckClick);
        laserButt.onClick.AddListener(laserClick);
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
        getInput();
        setRay();
    }

    void updateUI()
    {
        if ((hp <= 0) && (ended == false))
        {
            GameObject endgame = Instantiate(enderPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            ended = true;
        }
        hp_text.text = " Planet HP: " + hp;
    }

    void suckClick()
    {
        if(suck_active == false)
        {
            suck_active = true;
            suckButt.GetComponentInChildren<Text>().text = "Sucker - On";
        }
        else
        {
            suck_active = false;
            suckButt.GetComponentInChildren<Text>().text = "Sucker - Off";
        }
    }

    void laserClick()
    {
        laser_active = true;
        StartCoroutine(laserCoroutine());
    }

    IEnumerator laserCoroutine()
    {
        yield return new WaitForSeconds(1);
        laser_active = false;
    }

    void getInput()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            suck_active = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            laser_active = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            beam_active = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            suck_active = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            laser_active = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            beam_active = false;
        }
    }

    void setRay()
    {
        var ray_color = ray.GetComponent<Renderer>();
        if (suck_active == true)
        {
            ray_color.material.SetColor("_Color", Color.white);
        }
        if (laser_active == true)
        {
            ray_color.material.SetColor("_Color", Color.red);
        }
        if (beam_active == true)
        {
            ray_color.material.SetColor("_Color", Color.cyan);
        }
        if ((suck_active == false) && (laser_active == false) && (beam_active == false))
        {
            ray_color.material.SetColor("_Color", Color.magenta);
        }
    }

    void fireSuck()
    {

    }

    void fireLaser()
    {

    }

    void fireBeam()
    {

    }
}
