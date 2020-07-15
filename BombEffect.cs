using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public GameObject bossSound;
    LeftPartnerSkill LPS;
    RightPartnerSkill RPS;
    PlayerState ps;
    float stime;
    Allc allc;
    GameObject boss;
    // Use this for initialization
    void Start ()
    {
        stime = 0;
        LPS = GameObject.Find("Setup").GetComponent<LeftPartnerSkill>();
        RPS = GameObject.Find("Setup").GetComponent<RightPartnerSkill>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }
	
	// Update is called once per frame
	void Update () {

        if (allc.state == Allc.NOWSTATE.BOSS)
        {
            if (boss == null)
                boss = GameObject.FindWithTag("BossObject").gameObject;
        }

        if (allc == null)
            allc = GameObject.Find("Command").GetComponent<Allc>();
        if (stime > 1.0f)
        {
            this.transform.localScale *= 0.9f;
        }
        if (stime > 1.5f)
        {
            LPS.bombskill_activate = 0;
            RPS.bombskill_activate = 0;
            Destroy(this.gameObject);
        }
        stime += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalObject"|| other.gameObject.tag == "MonsterObject")
        {
            Destroy(other.gameObject);
            
                    Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "BossObject")
        {
            if (!other.GetComponent<BossState>().noDamage && allc.canBosshit)
            {
                if (bossSound != null)
                {
                    GameObject init = Instantiate(bossSound.transform.GetChild(boss.GetComponent<BossState>().nowStage - 1).gameObject, boss.transform.position, Quaternion.identity) as GameObject;
                }
                other.GetComponent<BossState>().nowHP -= 6f;
                other.GetComponent<BossState>().noDamage = true;
                other.GetComponent<BossState>().noDamageTw = true;
            }
        }
    }
}
