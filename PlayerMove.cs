using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //발사체 관련 변수
    public GameObject laserPrefab; //발사할 레이저를 저장합니다.
    public bool canShoot = true; //레이저를 쏠 수 있는 상태인지 검사합니다.
    const float shootDelay = 0.5f; //레이저를 쏘는 주기를 정해줍니다.
    float shootTimer = 0; //시간을 잴 타이머를 만들어줍니다.
    //

    //이동 관련 변수
    public const float moveSpeed = 10.0f; //움직이는 속도를 정의해 줍니다.
    //

    void Start()
    {

    }

    void Update()
    {
        moveControl(); //캐릭터를 움직이는 함수를 프레임마다 호출 합니다.
        ShootControl(); //스페이스바 입력시 발사
    }


    //발사체 관련 함수
    void ShootControl() // 발사를 관리하는 함수 입니다.
    {
        if (canShoot) // 쏠 수 있는 상태인지 검사합니다.
        {
            if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) //쿨타임이 지났는지와, 공격키인 스페이스가 눌려있는지 검사합니다.
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity); //레이저를 생성해줍니다.
                shootTimer = 0; //쿨타임을 다시 카운트 합니다.
            }
            shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
        }
    }
    //

    //이동 관련 함수
    void moveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다.
        this.gameObject.transform.Translate(distanceX, distanceY, 0);
        //이동량만큼 실제로 이동을 반영합니다.
    }
    //

}
