using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {
    public float HP_Value;//HP 바
    public Slider HP_Bar;//HP바
    public int PSA_L, PSA_R;//왼쪽 파트너, 오른쪽 파트너 상태
    public bool PartnerAcitve;
    public bool invincibility;
    public bool controlable;
    public bool L_skillToggle;
    public bool R_skillToggle;
    public bool PlayerHit;
    Allc allc;

    // Use this for initialization
    void Start()
    {
        PSA_L = PlayerPrefs.GetInt("partner1");
        PSA_R = PlayerPrefs.GetInt("partner2");
        PlayerHit = false;
        PartnerAcitve = false;
        invincibility = false;
        controlable = true;
        L_skillToggle = false;
        R_skillToggle = false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(HP_Bar == null)
        HP_Bar = GameObject.Find("Bar_Hp").GetComponent<Slider>();

        if(allc == null)
        allc = GameObject.Find("Command").GetComponent<Allc>();

        if (allc.state == Allc.NOWSTATE.FINISH)
        {
            Destroy(this.gameObject);
        }
        HP_Value = HP_Bar.value;
        DontDestroyOnLoad(gameObject);
    }
}
