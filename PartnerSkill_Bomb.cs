using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerSkill_Bomb : MonoBehaviour {
    PlayerState ps;
    Allc allc;
    public int skill_activate;
    float temps;
    public GameObject bomb;
    // Use this for initialization
    void Start()
    {
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        skill_activate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            temps = Time.time;

        }
        if (ps.R_skillToggle == true && (Time.time - temps) < 0.1 && skill_activate==0)
        {
            Debug.Log("Bomb Set Now");
            GameObject parent = GameObject.Find("PlayerSet");
            GameObject Instance = Instantiate(bomb, parent.transform.position, Quaternion.identity) as GameObject;
            Instance.transform.parent = parent.transform;            
            skill_activate = 1;
        }
    }
}
