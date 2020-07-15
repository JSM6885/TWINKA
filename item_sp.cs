using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_sp : MonoBehaviour {
    AllItem aitem;
    // Use this for initialization
    void Start()
    {
        aitem = GameObject.Find("AllItem").GetComponent<AllItem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            aitem.sp_on = true;            
        }
        Destroy(gameObject);
    }
}
