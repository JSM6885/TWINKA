using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerSkill_Slow : MonoBehaviour {
    PlayerState ps;
    Allc allc;
    public float bufftime = 0f;
    public float decreaseFactor = 1.0f;
    private bool buff_on = false;
    float temps;
    // Use this for initialization
    void Start () {
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            temps = Time.time;

        }
        if (ps.L_skillToggle == true && (Time.time - temps) < 0.1&&buff_on==false)
        {
            buff_on = true;
            bufftime = 3.0f;
            Debug.Log("Slow Set Now");
        }

        if (buff_on == true)
        {
            if (bufftime > 0)
            {
                Debug.Log("Slow Start Now");
                allc.objectSpeed = 5.0f * 0.2f;
                allc.backgroundSpeed = 0.06f * 0.2f;
                bufftime -= Time.deltaTime * decreaseFactor;
            }
            else if (bufftime <= 0)
            {
                Debug.Log("Slow End Now");
                allc.objectSpeed = 5.0f;
                allc.backgroundSpeed = 0.06f;
                ps.L_skillToggle = false;
                buff_on = false;
            }
        }
    }
}
