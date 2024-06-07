using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class LobbyCatMove : MonoBehaviour
{
    public Animator anim;
    float catSpeed = 0.001f;
    float sitTimer = 0f, sitWaitTime = 2f;          // 앉기 타이머, 앉을 때 까지의 시간

    Vector3 destPos;            // 목적지
    Vector3 dir;                    // 방향

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sitTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            SetDestination();

        if (sitTimer >= sitWaitTime)
            SitAnimChange();

        CatMove();

    }

    void SetDestination()
    {
        // 마우스 클릭 위치로 레이캐스트
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        // 레이캐스트 위치를 목적지로 설정
        if (Physics.Raycast(ray, out hit))
        {
            destPos = hit.point;


            // 목적지와의 거리가 멀면(0.05f 초과) 애니메이션 값 지정, 타이머 초기화
            if (Vector3.Distance(transform.position, destPos) > 0.05f)
            {
                sitTimer = 0f;
                anim.SetBool("isSitting", false);
                anim.SetBool("isMoving", true);
            }


            // 클릭된 콜라이더가 Floor이고 움직이는 중이면 방향설정, 방향을 바라보게함
            if (hit.collider.name == "Floor" && anim.GetBool("isMoving"))
            {
                dir = destPos - transform.position;
                transform.LookAt(destPos);
                Debug.Log(hit.point);
            }
        }
    }

    void CatMove()
    {
        // 이동
        if(anim.GetBool("isMoving"))
            transform.position += dir.normalized * catSpeed;

        // 목적지에 도달하면 (0.05f 이하) 이동 종료
        if (Vector3.Distance(transform.position, destPos) <= 0.05f)
        {
            anim.SetBool("isMoving", false);
        }
    }

    void SitAnimChange()
    {
        anim.SetBool("isSitting", true);
    }
}