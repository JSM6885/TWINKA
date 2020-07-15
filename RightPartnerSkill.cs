using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPartnerSkill : MonoBehaviour {
    PlayerState ps;
    Allc allc;
    AllItem allItem;
    float temps;
    GameObject boss;
    public GameObject skilleffect;
    public GameObject soundeffect;
    public GameObject bossSound;
    //--------------------------------------스킬 선택 변수???
    public int rightselect;
    //--------------------------------------스킬1 회복 관련
    private float Heal = 50.0f;
    //--------------------------------------스킬2 지진 관련
    public Transform camTransform;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private int shakeOn = 0;
    Vector3 originalPos;
    //--------------------------------------스킬3 폭탄 관련
    public int bombskill_activate;
    public GameObject bomb;
    //--------------------------------------스킬4 슬로우 관련
    public float slowtime = 0f;
    private bool buff_on = false;
    //--------------------------------------
    void Start()
    {
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        allItem = GameObject.Find("AllItem").GetComponent<AllItem>();
       // StartCoroutine(StartRutine());
        bombskill_activate = 0;
    }

    private void Awake()
    {
        if (camTransform == null)//스킬2 지진 관련
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void OnEnable()//스킬2 지진 관련
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (allc.state == Allc.NOWSTATE.BOSS)
        {
            if (boss == null)
                boss = GameObject.FindWithTag("BossObject").gameObject;
        }
        if (allc.skillavailable == true)
        {
            rightselect = ps.PSA_R;
            if (Input.GetMouseButtonDown(0))//클릭 시 시간 판별
            {
                temps = Time.time;
            }

            if (rightselect == 1 && (Time.time - temps) < 0.1 && ps.R_skillToggle == true)//스킬 판별 1번과 짧은 클릭의 경우 -- 회복 스킬을 사용할 경우
            {
                Skill_Heal();
                skilleffect.transform.GetChild(0).gameObject.SetActive(true);
                skilleffect.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                soundeffect.transform.GetChild(0).gameObject.SetActive(true);
                soundeffect.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            }

            if (rightselect == 2 && (Time.time - temps) < 0.1 && ps.R_skillToggle == true && shakeOn == 0)//스킬 판별 2번과 짧은 클릭의 경우 -- 지진 스킬을 사용할 경우
            {
                Skill_EarthQuake();
                skilleffect.transform.GetChild(1).gameObject.SetActive(true);
                skilleffect.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
                soundeffect.transform.GetChild(1).gameObject.SetActive(true);
                soundeffect.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
                soundeffect.transform.GetChild(2).gameObject.SetActive(true);
                soundeffect.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
                Delete();
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
                    skilleffect.transform.GetChild(1).gameObject.SetActive(false);
                    skilleffect.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
                    soundeffect.transform.GetChild(2).gameObject.SetActive(false);
                    soundeffect.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
                }
            }

            if (rightselect == 3 && (Time.time - temps) < 0.1 && bombskill_activate == 0 && ps.R_skillToggle == true)//스킬 판별 3번과 짧은 클릭의 경우 -- 폭탄 스킬을 사용할 경우
            {
                Debug.Log("Bomb Set Now");
                GameObject parent = GameObject.Find("PlayerSet");
                GameObject Instance = Instantiate(bomb, parent.transform.position, Quaternion.identity) as GameObject;
                Instance.transform.parent = parent.transform;
                bombskill_activate = 1;
                skilleffect.transform.GetChild(2).gameObject.SetActive(true);
                skilleffect.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
                soundeffect.transform.GetChild(3).gameObject.SetActive(true);
                soundeffect.transform.GetChild(3).gameObject.GetComponent<AudioSource>().Play();
                ps.R_skillToggle = false;
            }

            if (rightselect == 4 && (Time.time - temps) < 0.1 && buff_on == false && ps.R_skillToggle == true)//스킬 판별 4번과 짧은 클릭의 경우 -- 슬로우 스킬을 사용할 경우
            {
                buff_on = true;
                slowtime = 3.0f;
                Debug.Log("Slow Set Now");
                skilleffect.transform.GetChild(3).gameObject.SetActive(true);
                skilleffect.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
                soundeffect.transform.GetChild(5).gameObject.SetActive(true);
                soundeffect.transform.GetChild(5).gameObject.GetComponent<AudioSource>().Play();
                soundeffect.transform.GetChild(6).gameObject.SetActive(true);
                soundeffect.transform.GetChild(6).gameObject.GetComponent<AudioSource>().Play();
            }
            if (buff_on == true)
            {
                if (slowtime > 0)
                {
                    Debug.Log("Slow Start Now");
                    Time.timeScale = 0.5f;
                   // allc.objectSpeed = 5.0f * 0.2f;
                   // allc.backgroundSpeed = 0.06f * 0.2f;
                    slowtime -= Time.deltaTime * decreaseFactor;
                }
                else if (slowtime <= 0)
                {
                    Debug.Log("Slow End Now");
                    Time.timeScale = 1.0f;
                    // allc.objectSpeed = 5.0f;
                    // allc.backgroundSpeed = 0.06f;
                    buff_on = false;
                    ps.R_skillToggle = false;
                    skilleffect.transform.GetChild(3).gameObject.SetActive(false);
                    skilleffect.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
                    soundeffect.transform.GetChild(6).gameObject.SetActive(false);
                    soundeffect.transform.GetChild(6).gameObject.GetComponent<AudioSource>().Play();
                }
                if(slowtime > 0 && allItem.buff_on == true)
                {
                    Debug.Log("Slow End Now");
                    Time.timeScale = 1.0f;
                    // allc.objectSpeed = 5.0f;
                    // allc.backgroundSpeed = 0.06f;
                    buff_on = false;
                    ps.R_skillToggle = false;
                    skilleffect.transform.GetChild(3).gameObject.SetActive(false);
                    skilleffect.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
                    soundeffect.transform.GetChild(6).gameObject.SetActive(false);
                    soundeffect.transform.GetChild(6).gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
        else if (allc.skillavailable == false)
        {

        }
    }
    void Skill_Heal()
    {
        ps.HP_Bar.value += Heal;
        Debug.Log("Heal Now");
        ps.R_skillToggle = false;
    }

    void Skill_EarthQuake()
    {
        shakeOn = 1;
        shake = 1.2f;
        Delete();
        Debug.Log("TSkill Set Now");
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
        GameObject[] tempobj2 = GameObject.FindGameObjectsWithTag("MonsterObject");
        foreach (GameObject ob in tempobj2)
        {
            if (ob.transform.position.y < 5)
            {
                Destroy(ob.gameObject);
            }
        }

        if (allc.state == Allc.NOWSTATE.BOSS)
        {
            if (!boss.GetComponent<BossState>().noDamage && allc.canBosshit)
            {
                if (bossSound != null)
                {
                    GameObject init = Instantiate(bossSound.transform.GetChild(boss.GetComponent<BossState>().nowStage - 1).gameObject, boss.transform.position, Quaternion.identity) as GameObject;
                }
                boss.GetComponent<BossState>().nowHP -= 6f;
                boss.GetComponent<BossState>().noDamage = true;
                boss.GetComponent<BossState>().noDamageTw = true;
            }
        }
    }
}
