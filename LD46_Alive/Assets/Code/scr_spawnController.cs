using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawnController : MonoBehaviour
{
    public GameObject FactoryPrefab;
    public int initialSpawn = 5;
    public int spawnRate;

    public GameObject earf;

    // Start is called before the first frame update
    void Start()
    {
        //earf = GameObject.Find("Planet_controller");  
        for(int i = 0; i< initialSpawn; i++)
        {
            spawnFactory();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFactory()
    {
        //Get center point & randomize placement 
        
        Vector3 spawnPoint = earf.transform.position;
        Vector3 randomDir = Random.onUnitSphere;
        spawnPoint += (randomDir * (earf.transform.localScale.y/2));
        Vector3 spawnRotation = (spawnPoint - earf.transform.position).normalized;
        

        //Spawn & rotate & parent appropriately
        GameObject addSpawn = Instantiate(FactoryPrefab, spawnPoint, new Quaternion(0, 0, 0, 0));
       addSpawn.transform.rotation = Quaternion.FromToRotation(addSpawn.transform.up, spawnRotation) * addSpawn.transform.rotation;

        addSpawn.transform.parent = earf.transform;

    }
}
