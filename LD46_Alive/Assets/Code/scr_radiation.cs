﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_radiation : MonoBehaviour
{
    public GameObject RadPrefab;
    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
    bool orbiting = true;
    bool freezed = false;
    public int lifetime;
    public int damage;
    GameObject player;
    [SerializeField] GameObject IcePrefab;
    int set;
    bool invulnerable = true;

    // Start is called before the first frame update
    void Start()
    {
        set = Random.Range(1, 4);
        StartCoroutine("kysCoroutine");
        player = GameObject.Find("Space_station");
        StartCoroutine("invCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (orbiting == true)
        {
            orbit();
        }
        else
        {
            /*
            if (freezed == true)
            {
                // frozen(); // Conceal, don't feel
            }
            else
            {
                sucked();
            }
            */
        }
    }

    IEnumerator kysCoroutine()
    {
        yield return new WaitForSeconds(lifetime);
        player.GetComponent<scr_player>().hp = player.GetComponent<scr_player>().hp - damage;
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        evalRay(other);
    }

    void OnTriggerStay(Collider other)
    {
        evalRay(other);
    }

    void evalRay(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool suckage = GameObject.Find("Space_station").GetComponent<scr_player>().suck_active;
            bool lasering = GameObject.Find("Space_station").GetComponent<scr_player>().laser_active;
            bool freezing = GameObject.Find("Space_station").GetComponent<scr_player>().beam_active;
            if ((suckage == true) && (invulnerable == false))
            {
                if (freezed == false)
                {
                    GameObject airRadiation = Instantiate(RadPrefab, transform.position, transform.rotation);
                    airRadiation.transform.parent = GameObject.Find("Planet_controller").transform;
                    invulnerable = true;
                    StartCoroutine("invCoroutine");
                }
                else
                {
                    sucked();
                }
            }
            if (lasering == true)
            {
                if ((freezed == false) && (invulnerable == false))
                {
                    player.GetComponent<scr_player>().hp = player.GetComponent<scr_player>().hp - (damage * 2);
                    Destroy(gameObject);
                }
                else
                {
                    thawed();
                }
            }
            if ((freezing == true) && (freezed == false))
            {
                frozen();
                orbiting = false;

            }
        }
        if (other.gameObject.CompareTag("station"))
        {
            Destroy(gameObject);
        }
    }

    void orbit()
    {
        // Spin the object around the world origin in a random direction at 10 degrees/second.
        if (set == 1)
        {
            transform.RotateAround(target, new Vector3(1, 0, 0), 10 * Time.deltaTime);
        }
        if (set == 2)
        {
            transform.RotateAround(target, new Vector3(-1, 0, 0), 10 * Time.deltaTime);
        }
        if (set == 3)
        {
            transform.RotateAround(target, new Vector3(0, 0, 1), 10 * Time.deltaTime);
        }
        if (set == 4)
        {
            transform.RotateAround(target, new Vector3(0, 0, -1), 10 * Time.deltaTime);
        }
    }

    void sucked()
    {
        float step = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0.686f, -0.471f), step);
    }

    void frozen()
    {
        StopCoroutine("kysCoroutine");
        orbiting = false;
        freezed = true;
        GameObject elsa = Instantiate(IcePrefab, transform.position, transform.rotation);
        elsa.transform.parent = transform;
        StartCoroutine("iceCoroutine");
    }

    IEnumerator iceCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject.transform.GetChild(0).gameObject); // let it go
        freezed = false;
        orbiting = true;
        StartCoroutine("kysCoroutine");
    }

    void thawed()
    {
        StopCoroutine("iceCoroutine");
        if (this.gameObject.transform.childCount != 0)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject); // let it go
        }
        freezed = false;
        invulnerable = true;
        StartCoroutine("invCoroutine");
    }

    IEnumerator invCoroutine()
    {
        yield return new WaitForSeconds(1);
        invulnerable = false;
    }
}
