using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner_WolfA : MonoBehaviour
{
    PlayerState ps;
    Allc allc;
    private float Heal = 50.0f;
    public float bufftime = 0f;
    public float decreaseFactor = 1.0f;
    float temps;
    void Start()
    {
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            temps = Time.time;

        }
        if (ps.L_skillToggle == true && (Time.time - temps) < 0.1)
        {
            Skill01();
        }

    }
    void Skill01()
    {
        ps.HP_Bar.value += Heal;
        Debug.Log("Heal Now");
        ps.L_skillToggle = false;

    }
}
