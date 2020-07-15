using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Partner_TurtleA : MonoBehaviour
{
    Allc allc;
    public Transform camTransform;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private int shakeOn = 0;
    Vector3 originalPos;
    PlayerState ps;
    float temps;
    private void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }
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
        if (ps.R_skillToggle == true && (Time.time - temps) < 0.1 && shakeOn == 0)
        {
            shakeOn = 1;
            shake = 1.2f;
            Delete();
            Debug.Log("TSkill Set Now");
        }
        if (shakeOn == 1)
        {
            if (shake > 0)
            {
                Debug.Log("TSkill Go Now");
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shake -= Time.deltaTime * decreaseFactor;
            }
            else if (shake <= 0)
            {
                Debug.Log("TSkill End Now");
                shake = 0f;
                camTransform.localPosition = originalPos;
                shakeOn = 0;
                ps.R_skillToggle = false;
            }
        }
    }
    void Delete()
    {
        GameObject[] tempobj = GameObject.FindGameObjectsWithTag("NormalObject");
        foreach (GameObject ob in tempobj)
        {
            if (ob.transform.position.y < 5)
            {
                Destroy(ob.gameObject);
            }
        }

    }
}
