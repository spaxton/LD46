using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HPeval : MonoBehaviour
{
    public bool at70 = false;
    public bool at30 = false;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int hp = player.GetComponent<scr_player>().hp;
        if (hp <= 70)
        {
            at70 = true;
        }
        if (hp <= 30)
        {
            at30 = true;
        }
    }
}
