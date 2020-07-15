using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner_Left : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject obj;
    float temps;
    bool click_can; //스킬 사용 가능 여부???
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//마우스 버튼 클릭시 시간
        {
            temps = Time.time;

        }

        if (Input.GetMouseButtonUp(0))
        {
            if ((Time.time - temps) < 0.3)//클릭한 시간이 짧을 경우
            {
                // short click effect
                // put what happens in the short click here
                Delete();//장애물 제거 실행
            }
        }

        if (Input.GetMouseButton(0))
        {
            if ((Time.time - temps) > 0.3)//클릭한 시간이 길 경우 = 드래그를 해서 캐릭터를 이동하려할 때
            {
                // long click effect
                // put whatever you want to do during the long click
                //아무 것도 실행하지 않음
            }
        }
    }
    void Delete()//장애물 제거
    {
        // if (Input.GetMouseButtonUp(0))
        //  {
        //  ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //   if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //  {
        //  if (hit.transform.gameObject == gameObject)
        //  {
        /* for (int i = 0; i < 10; i++)
         {
             obj[i] = GameObject.FindWithTag("Wall");
             Destroy(obj[i]);
         }*/
        GameObject[] tempobj = GameObject.FindGameObjectsWithTag("NormalObject");//Wall 태그를 가진 오브젝트를 배열에 넣음
        foreach (GameObject ob in tempobj)//전부 제거
        {
            Destroy(ob.transform.parent.gameObject);
        }

        //  }
        // }
        // }
    }

}
