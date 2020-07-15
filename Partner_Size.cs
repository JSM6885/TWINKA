using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Partner_Size : MonoBehaviour
{
    public int left, right;
    public GameObject[] part_L = new GameObject[4];//왼쪽 파트너
    public GameObject[] part_R = new GameObject[4];//오른쪽 파트너
    public Slider ps_1;//왼쪽 오른쪽 파트너 게이지바?
    public float gauge_value;//??
    public Image[] Skill_Crystal;
    public GameObject[] Emblam = new GameObject[4];

    public GameObject splight;

    //  public int PSA_L, PSA_R;//왼쪽 오른쪽 파트너 판별 값
    Allc allc;//올커맨드 참조
    float temps;//클릭 시간 측정
    PlayerState ps;

    void Start()
    {
        allc = GameObject.Find("Command").GetComponent<Allc>();//올커맨드 참조
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }

    void Update()
    {
        if (splight == null)
            splight = GameObject.Find("SP_LIGHT").gameObject;

        if(ps_1 == null)
            ps_1 = GameObject.Find("bar_char1").GetComponent<Slider>();

        if(Skill_Crystal[0] == null)
            Skill_Crystal[0] = GameObject.Find("Enable_Skill1").transform.GetChild(1).GetComponent<Image>();
        if(Skill_Crystal[1] == null)
            Skill_Crystal[1] = GameObject.Find("Enable_Skill2").transform.GetChild(1).GetComponent<Image>();
        if(Skill_Crystal[2] == null)
            Skill_Crystal[2] = GameObject.Find("Enable_Skill3").transform.GetChild(1).GetComponent<Image>();
        if(Skill_Crystal[3] == null)
            Skill_Crystal[3] = GameObject.Find("Enable_Skill4").transform.GetChild(1).GetComponent<Image>();

        left = ps.PSA_L;
        right = ps.PSA_R;

        ps_1.value += gauge_value;
        if(ps_1.value >=200)
        {
            Skill_Crystal[0].gameObject.SetActive(true);//스킬 게이지 1번 칸? 활성화 
            splight.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(ps_1.value < 200)
        {
            Skill_Crystal[0].gameObject.SetActive(false);//1번칸 비활성화
            splight.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (ps_1.value >= 400)
        {
            Skill_Crystal[1].gameObject.SetActive(true);//스킬 게이지 2번 칸? 활성화
            splight.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (ps_1.value < 400)
        {
            Skill_Crystal[1].gameObject.SetActive(false);//2번칸 비활성화
            splight.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (ps_1.value >= 600)
        {
            Skill_Crystal[2].gameObject.SetActive(true);//스킬 게이지 3번 칸? 활성화
            splight.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (ps_1.value < 600)
        {
            Skill_Crystal[2].gameObject.SetActive(false);//3번칸 비활성화
            splight.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (ps_1.value >= 800)
        {
            Skill_Crystal[3].gameObject.SetActive(true);//스킬 게이지 4번 칸? 활성화
            splight.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (ps_1.value < 800)
        {
            Skill_Crystal[3].gameObject.SetActive(false);//4번칸 비활성화
            splight.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))//마우스 버튼 누르는 순간부터 시간
        {
            temps = Time.time;//시간 측정
        }

        if (Input.GetMouseButtonUp(0) && ps.controlable == true)//마우스 버튼 땠을 시
        {
            if ((Time.time - temps) < 0.2 && ps.R_skillToggle == false && ps.L_skillToggle == false && allc.skillavailable==true)//클릭한 시간이 짧을 경우
            {
                if (ps_1.value >= 200)
                {
                    if (ps.PartnerAcitve == false)
                    {
                        ps.PartnerAcitve = true;//파트너 왼쪽을 크게 판별 변경
                        ps.L_skillToggle = true;
                        ps_1.value -= 200;
                    }
                    else if (ps.PartnerAcitve == true)
                    {

                        ps.PartnerAcitve = false;//파트너 오른쪽을 크게 판별 변경
                        ps.R_skillToggle = true;
                        ps_1.value -= 200;
                    }
                }
            }
        }

        if (ps.PartnerAcitve == false)//파트너 왼쪽을 크게
        {
            part_L[left-1].SetActive(true);
            part_R[right - 1].SetActive(false);
            Emblam[right-1].gameObject.SetActive(true);
            Emblam[left-1].gameObject.SetActive(false);
        }
        else if (ps.PartnerAcitve == true)//파트너 오른쪽을 크게
        {
            part_R[right - 1].SetActive(true);
            part_L[left - 1].SetActive(false);
            Emblam[left - 1].gameObject.SetActive(true);
            Emblam[right - 1].gameObject.SetActive(false);
        }
    }
}
