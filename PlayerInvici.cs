using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvici : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    Allc allc;
    PlayerState ps;
    AllItem aitem;
    // Use this for initialization
    void Start () {
        allc = GameObject.Find("Command").GetComponent<Allc>();
        ps = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        aitem = GameObject.Find("AllItem").GetComponent<AllItem>();
    }
	
	// Update is called once per frame
	void Update () {
		if(ps.invincibility==true)
        {
            UnBeatTime();
        }
	}
    IEnumerator UnBeatTime()
    {
        /*int countTime = 0;
        while (ps.invincibility==true)
        {
            if (countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
               spriteRenderer.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);

        ps.invincibility = false;*/

        yield return null;
    }
}
