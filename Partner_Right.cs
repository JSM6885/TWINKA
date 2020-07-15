using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner_Right : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit; 
    private GameObject obj;
    float timer;
    float temps;
    bool click_can; //스킬 사용 가능 여부???
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            temps = Time.time;

        }

        if (Input.GetMouseButtonUp(0))
         {
          if ((Time.time - temps) < 0.2)
        {
                // short click effect
                // put what happens in the short click here
                Delete();
            } }

        if (Input.GetMouseButton(0)) {
            if ((Time.time - temps) > 0.2)
            {
                // long click effect
                // put whatever you want to do during the long click

            } }
    }
    void Delete()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    /* for (int i = 0; i < 10; i++)
                     {
                         obj[i] = GameObject.FindWithTag("Wall");
                         Destroy(obj[i]);
                     }*/
                    GameObject[] tempobj = GameObject.FindGameObjectsWithTag("NormalObject");
                    foreach (GameObject ob in tempobj)
                    {
                        Destroy(ob.transform.parent.gameObject);
                        timer = 0;
                    }

                }
            }
        }
    }
}
