using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
public class Wall_test : MonoBehaviour
{
    public SkeletonAnimation sa;
    public GameObject bossshot;
    public GameObject management;
    public float twincleTime;
    private GameObject colobj;
    private Vector3 m_vPos;
    public Slider HP_Bar;
    public int Damage;
    bool toggle = false;
    float twtime;
    Allc allc;
    bool colorSwith;
    PlayerState ps;
    AllItem aitem;
    private float invincibility_time;
    public float invincibility;
    public float decreaseFactor = 0.3f;
    private int invicible_color = 0;
    public GameObject skilleffect;
    public GameObject soundeffect;
    public GameObject HitDieSound;

    // Use this for initialization
    void Start()
    {
        Damage = 15;
        colorSwith = true;
        twtime = 0;
        invincibility_time = 0;
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        aitem = GameObject.Find("AllItem").GetComponent<AllItem>();
        colobj = this.gameObject;
        SkeletonAnimation sa = gameObject.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP_Bar == null)
            HP_Bar = GameObject.Find("Bar_Hp").GetComponent<Slider>();

        if (management == null)
            management = GameObject.Find("Command").gameObject;

        if (toggle)
        {
            if (colobj.gameObject != null)
            {
                m_vPos = new Vector3(colobj.gameObject.transform.position.x + 0.05f, colobj.gameObject.transform.position.y - 1.0f, 0);
                this.transform.parent.transform.position = Vector3.Lerp(transform.position, m_vPos, 5.0f * Time.deltaTime);
                this.transform.parent.transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
                if (transform.parent.transform.localScale.x < 0f)
                {
                    toggle = false;
                }
            }           
        }
        if (ps.invincibility == true && invincibility_time > 0)
        {
            if(twtime > twincleTime)
            {
                if (colorSwith == true)
                {
                    sa.skeleton.SetColor(new Color(1, 0.7f, 0.7f));
                }
                else
                {
                    sa.skeleton.SetColor(new Color(1, 1, 1));
                }
                colorSwith = !colorSwith;
                twtime = 0;
            }
            twtime += Time.deltaTime;

            //sa.skeleton.SetColor(new Color(1,0.4f,0.4f));
            invincibility_time -= Time.deltaTime * decreaseFactor;            
        }
        else if (ps.invincibility == true && invincibility_time <= 0 && aitem.shield_on == 0 && aitem.buff_on == false)
        {
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            twtime = 0;
            sa.skeleton.SetColor(new Color(1, 1, 1));
            invincibility_time = 0.0f;
            ps.invincibility = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalObject" && aitem.buff_on == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "NonBObject" && aitem.buff_on == true)
        {
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "NormalObject" && ps.invincibility == false)
        {
            HP_Bar.value -= Damage;
            ps.PlayerHit = true;
            invincibility_time = invincibility;
            ps.invincibility = true;
        }


        if (other.gameObject.tag == "BulletObject" && ps.invincibility == false)
        {
            HP_Bar.value -= Damage;
            ps.PlayerHit = true;
            invincibility_time = invincibility;
            ps.invincibility = true;
        }

        if (other.gameObject.tag == "NonBObject" && ps.invincibility == false)
        {
            HP_Bar.value -= Damage;
            ps.PlayerHit = true;
            invincibility_time = invincibility;
            ps.invincibility = true;
        }

        if (other.gameObject.tag == "BossObject" && ps.invincibility == false)
        {
            HP_Bar.value -= Damage;
            ps.PlayerHit = true;
            invincibility_time = invincibility;
            ps.invincibility = true;
        }


        if (other.gameObject.tag == "SingleFlat")
        {
            FlatToObj flat = other.GetComponent<FlatToObj>();
            GameObject parents = flat.transform.parent.gameObject;
            m_vPos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0);
            Destroy(other.gameObject);
            Destroy(flat.partner_obj.gameObject);
            GameObject.Instantiate(flat.replace_obj, m_vPos, Quaternion.identity).transform.parent = parents.transform;
        }

        if (other.gameObject.tag == "DoubleFlat")
        {
            FlatToObj flat = other.GetComponent<FlatToObj>();
            GameObject parents = flat.transform.parent.gameObject;
            m_vPos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0);
            Destroy(other.gameObject);
            GameObject.Instantiate(flat.replace_obj, m_vPos, Quaternion.identity).transform.parent = parents.transform;

            m_vPos = new Vector3(flat.partner_obj.gameObject.transform.position.x, flat.partner_obj.gameObject.transform.position.y, 0);
            Destroy(flat.partner_obj.gameObject);

            GameObject obj2 = Instantiate(flat.partner_rep, m_vPos, Quaternion.identity) as GameObject;
            obj2.transform.parent = parents.transform;

            FlatToObj flat2 = obj2.GetComponent<FlatToObj>();

            flat2.partner_obj = flat.last_obj;
            flat2.replace_obj = flat.replace_obj;
        }


        /* 
         if (other.gameObject.tag == "Portal")
         {
             colobj = other.gameObject;

             toggle = true;
         }

         * GameObject[] tempobj = GameObject.FindGameObjectsWithTag("Wall");//Wall 태그를 가진 오브젝트를 배열에 넣음
         foreach (GameObject ob in tempobj)//전부 제거
         {
             if (ob.transform.position.y < 5)
             {
                 Destroy(ob.gameObject);
             }
         }*/

        if (other.gameObject.tag == "BOOSTER")
        {
            soundeffect.transform.GetChild(7).gameObject.SetActive(true);
            soundeffect.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            soundeffect.transform.GetChild(8).gameObject.SetActive(true);
            soundeffect.transform.GetChild(8).gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            aitem.bufftime = 2.0f;
            aitem.buff_on = true;
        }
        if (other.gameObject.tag == "SHIELD")
        {
            soundeffect.transform.GetChild(10).gameObject.SetActive(true);
            soundeffect.transform.GetChild(10).gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            aitem.shield_on = 1;
        }
        if (other.gameObject.tag == "HEART")
        {
            soundeffect.transform.GetChild(9).gameObject.SetActive(true);
            soundeffect.transform.GetChild(9).gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            aitem.sp_on = true;
        }


        ////////////////////////////////////////////////    score      //////////////////////////////////////////////////////////////////////////////
        if (other.gameObject.tag == "Score")
        {
            allc.score += 1000;
            ScoreManager.instance.AddScore((int)allc.score);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BigScore")
        {
            allc.score += 10000;
            ScoreManager.instance.AddScore((int)allc.score);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "totem_normal")
        {
            allc.score += 10000;
            ScoreManager.instance.AddScore((int)allc.score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "totem_heal")
        {
            HP_Bar.value += 20;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "totem_nega")
        {
            GameObject Instance = Instantiate(GameObject.Find("Setup").GetComponent<backGroundSetUp>().Pattern[6], m_vPos, Quaternion.identity) as GameObject;
        }
    }
}

