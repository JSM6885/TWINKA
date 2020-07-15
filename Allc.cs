using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allc : MonoBehaviour {

    public bool NewGameToggle;
    public bool c1 , c2, c3;
    public bool docutscene; 
    public float backgroundSpeed; //배경화면 출력 속도
    public float objectSpeed; //전체 게임 속도
    public float left_end, right_end, top_end, bottom_end; //화면 이동제한
    public enum NOWSTATE { LOBY, CUT, STAGE, BOSS, BONUS, FINISH, RESET }; //현재 상태
   // public int HP_Value;
   // public int PSA_L, PSA_R;


    public bool observPat;

    public int apearE = 1;
    public int nowpattern = 1;
    public int patternCnt = 0;


    public bool BosshitToggle;
    public bool canBosshit;
    public NOWSTATE state;

    public float score;
    public bool bossstage;

    public bool bounsstage;
    public bool skillavailable;
    // Use this for initialization
    void Start()
    {
        docutscene = true;
        score = 0;
        NewGameToggle = false;
        observPat = true;
        state = NOWSTATE.STAGE;
        backgroundSpeed = 0.06f;
        objectSpeed = 1.0f;
        left_end = -2.5f;
        right_end = 2.5f;
        top_end = 4.3f;
        bottom_end = -4.3f;
        // PSA_L = 0;
        // PSA_R = 1;
        nowpattern = 1;
        apearE = 1;
        BosshitToggle = false;
        canBosshit = false;
        bounsstage = false;
        c1 = true;
        //c1 =false;
        c2 = false;
        c3 = false;
        skillavailable = true;     
    }
    private void Awake()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update() {
        if (state == NOWSTATE.FINISH)
        {
            Destroy(this.gameObject);
        }
        if (NewGameToggle)
        {
            state = NOWSTATE.FINISH;
        }
        DontDestroyOnLoad(gameObject);
        left_end = -2.5f;
        right_end = 2.5f;
        bottom_end = -4.3f;
    }
}
