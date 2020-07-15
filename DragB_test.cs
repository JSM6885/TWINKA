
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DragB_test : MonoBehaviour {
    public GameObject obj;
    private Vector3 suvV = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float distance = 10;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, distance);
       // subX = mousePosition.x - obj.transform.position.x;
       // subY = mousePosition.y - obj.transform.position.y;

      //  mousePosition.x -= subX;
      //  mousePosition.x -= subX;

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        obj.transform.position = objPosition;
    }
}
