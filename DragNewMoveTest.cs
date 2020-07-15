using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;




public class DragNewMoveTest : MonoBehaviour
{
    //public GameObject management;
    public float left_end, right_end, top_end, bottom_end;
    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    private Vector3 targetPos = Vector3.zero;
    private bool isClicked = false;
    private float moveTime;

    private Vector3 nowPos;
    private Vector3 befPos;

    int direction;
    int befdirection;
    Allc allc;

    bool moveToggle;

    public bool touching;
    private void Start()
    {
        moveToggle = true;
        touching = false;
        nowPos = this.transform.position;
        befPos = this.transform.position;
        moveTime = 0f;
        direction = 0;
        befdirection = 0;
        allc = allc = GameObject.Find("Command").GetComponent<Allc>();
    }

    void Update()
    {


        if (moveTime > 0.1f)
        {
            nowPos = this.transform.position;
            if (befPos.x < nowPos.x)
            {
                if (moveToggle)
                {
                    this.gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "flyR", true);
                    moveToggle = false;
                }
                direction = 1;
            }
            if (befPos.x == nowPos.x)
            {
                if (moveToggle)
                {
                    this.gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "fly", true);
                    moveToggle = false;
                }
                direction = 0;
            }
            if (befPos.x > nowPos.x)
            {
                if (moveToggle)
                {
                    this.gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "flyL", true);
                    moveToggle = false;
                }
                direction = -1;
            }
        }

        if(befdirection != direction)
        {
            moveTime = 0;
            moveToggle = true;
        }

        befdirection = direction;
        moveTime+=Time.deltaTime;
        befPos = nowPos;


        left_end = allc.left_end;
        right_end = allc.right_end;
        top_end = allc.top_end;
        bottom_end = allc.bottom_end;
        DragObject();
    }

    void DragObject()
    {
        if (Input.touchCount <= 1)
        {
            if (Input.GetMouseButtonDown(0) && touching == false)
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isClicked = true;
                touching = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                touching = false;
            }

            if (isClicked)
            {
                if (Input.GetMouseButton(0))

                    endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos = endPos - startPos;
                startPos = endPos;

                if (allc.bounsstage == false)
                {
                    float x = transform.position.x;
                    x = Mathf.Min(Mathf.Max(x, left_end), right_end);

                    float y = transform.position.y;
                    y = Mathf.Min(Mathf.Max(y, bottom_end), top_end);

                    transform.position = new Vector3(x, y, transform.position.z);

                    targetPos = new Vector3(targetPos.x, targetPos.y, 0);
                    transform.position += targetPos;
                }
                else if (allc.bounsstage == true)
                {
                    float x = transform.position.x;
                    x = Mathf.Min(Mathf.Max(x, left_end), right_end);

                    transform.position = new Vector3(x, -4.3f, transform.position.z);

                    targetPos = new Vector3(targetPos.x, 0, 0);
                    transform.position += targetPos;
                }

            }
        }
    }

}

/*public void pushObjectBackInFrustum(Transform obj)
  {
      Vector3 pos = Camera.main.WorldToViewportPoint(obj.position);
  
      if(pos.x< 0f)
          pos.x = 0f;
  
     if(pos.x > 1f)
          pos.x = 1f;
 
     if(pos.y< 0f)
         pos.y = 0f;
  
    if(pos.y > 1f)
         pos.y = 1f;
 
     obj.position = Camera.main.ViewportToWorldPoint(pos);
 }*/

