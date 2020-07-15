using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_shield : MonoBehaviour {
    AllItem aitem;
    // Use this for initialization
    void Start()
    {
        aitem = GameObject.Find("AllItem").GetComponent<AllItem>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            aitem.shield_on =1;
        }
        Destroy(gameObject);
    }
}
