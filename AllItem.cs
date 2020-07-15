using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllItem : MonoBehaviour {
    public float bufftime = 0f;
    public float decreaseFactor = 1.0f;
    public float bufftime2 = 0f;
    public bool buff_on = false;
    PlayerState ps;
    Allc allc;
    public Slider ps_1;
    public bool sp_on = false;
    public int shield_on = 0;
    public GameObject Shield_item;
    public GameObject skilleffect;
    bool booster_toggle;
    bool mana_toggle;
    public GameObject soundeffect;
    void Start () {
        booster_toggle=true;
        mana_toggle = true;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update () {
        if(ps == null)
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();

        if(allc == null)
        allc = GameObject.Find("Command").GetComponent<Allc>();

        if(ps_1 == null)
        ps_1 = GameObject.Find("bar_char1").GetComponent<Slider>();

        if (skilleffect == null)
            skilleffect = GameObject.Find("SkillEffect").gameObject;


        if (soundeffect == null)
            soundeffect = GameObject.Find("Sound").gameObject;


        if (allc.state == Allc.NOWSTATE.FINISH)
        {
            Destroy(this.gameObject);
        }
        if (buff_on == true)
        {
            if (bufftime > 0)
            {
                Time.timeScale = 1.0f;
                Debug.Log("RunItem Start Now");
                ps.controlable = false;
                allc.objectSpeed = 1.0f * 2.2f;
                allc.backgroundSpeed = 0.06f * 2.2f;
                bufftime -= Time.deltaTime * decreaseFactor;
                if (booster_toggle)
                {
                    skilleffect.transform.GetChild(6).gameObject.SetActive(true);
                    skilleffect.transform.GetChild(6).gameObject.GetComponent<ParticleSystem>().Play();
                    booster_toggle = false;
                }
            }
            else if (bufftime <= 0)
            {
                soundeffect.transform.GetChild(8).gameObject.SetActive(false);
                soundeffect.transform.GetChild(8).gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("RunItem End Now");
                ps.controlable = true;
                allc.objectSpeed = 1.0f;
                allc.backgroundSpeed = 0.06f;
                buff_on = false;
                skilleffect.transform.GetChild(6).gameObject.SetActive(false);
                booster_toggle = true;
            }
        }

        if(sp_on==true)
        {
            if(mana_toggle==true)
            {
                skilleffect.transform.GetChild(7).gameObject.SetActive(true);
                skilleffect.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
                mana_toggle = false;
            }
            if(ps_1.value+500>1000)
            {
                ps_1.value = 1000;
            }
            else
            {
                ps_1.value += 500;
            }
            sp_on = false;
            mana_toggle = true;
        }

        if(shield_on==1)
        {
            ps.invincibility = true;
            GameObject parent = GameObject.Find("Player");
            GameObject Instance = Instantiate(Shield_item, parent.transform.position, Quaternion.identity) as GameObject;
            Instance.transform.parent = parent.transform;
            shield_on = 2;
        }
        else if(shield_on==3)
        {
            bufftime2 = 1.2f;
            shield_on = 4;
        }
        if (bufftime2 > 0)
        {
            bufftime2 -= Time.deltaTime * decreaseFactor;
            ps.PlayerHit = false;
        }
        else if (bufftime2 <= 0 && ps.PlayerHit == false)
        {
            soundeffect.transform.GetChild(11).gameObject.SetActive(true);
            soundeffect.transform.GetChild(11).gameObject.GetComponent<AudioSource>().Play();
            ps.invincibility = false;
            bufftime2 = 0;
            shield_on = 0;
        }
    }
}
