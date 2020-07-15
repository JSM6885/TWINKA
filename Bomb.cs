using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombeffect;
    public float moveSpeed = 5.0f;
    float stime;
    LeftPartnerSkill LPS;
    RightPartnerSkill RPS;
    // Use this for initialization
    void Start()
    {

        LPS = GameObject.Find("Setup").GetComponent<LeftPartnerSkill>();
        RPS = GameObject.Find("Setup").GetComponent<RightPartnerSkill>();
        stime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        transform.parent = null;
        if (this.transform.position.y > 5.5f)
        {
            //Instance.transform.parent = parent.transform;
            LPS.bombskill_activate = 0;
            RPS.bombskill_activate = 0;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "NormalObject"|| other.gameObject.tag == "MonsterObject" || other.gameObject.tag == "BossObject")
        {
            GameObject parent = GameObject.Find("Bomb(Clone)");
            GameObject Instance = Instantiate(bombeffect, parent.transform.position, Quaternion.identity) as GameObject;
            //Instance.transform.parent = parent.transform;
            Destroy(gameObject);
        }

        
    }
}