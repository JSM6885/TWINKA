using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_item_effect : MonoBehaviour
{
    AllItem aitem;
    PlayerState ps;
    // Use this for initialization
    void Start()
    {
        aitem = GameObject.Find("AllItem").GetComponent<AllItem>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "NormalObject" || other.gameObject.tag == "MonsterObject")
        {
            Destroy(other.gameObject);
            
            aitem.shield_on = 3;
            Destroy(gameObject);
        }
    }
}
