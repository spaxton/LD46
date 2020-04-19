using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_factory : MonoBehaviour
{
    public GameObject PolPrefab;
    public GameObject earf;

    // Start is called before the first frame update
    void Start()
    {
        earf = GameObject.Find("Planet_controller");
        spawnAirPol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnAirPol()
    {
        GameObject airPollution = Instantiate(PolPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        airPollution.transform.parent = earf.transform;
    }
}
