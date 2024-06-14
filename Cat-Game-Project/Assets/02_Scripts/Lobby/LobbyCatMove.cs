using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LobbyCatMove : MonoBehaviour
{
    public Animator anim;
    float catSpeed = 0.01f;
    //float sitTimer = 0f, sitWaitTime = 2f;          // �ɱ� Ÿ�̸�, ���� �� ������ �ð�

    Vector3 destPos;            // ������
    Vector3 dir;                    // ����


    void Update()
    {
        //sitTimer += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "SleepingScene")
            anim.SetBool("isSitting", true);
        else if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            anim.SetBool("isSitting", false);
            SetDestination();
        }


        CatMove();
    }

    void SetDestination()
    {
        // ���콺 Ŭ�� ��ġ�� ����ĳ��Ʈ
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        // ����ĳ��Ʈ ��ġ�� �������� ����
        if (Physics.Raycast(ray, out hit))
        {
            destPos = hit.point;


            // ���������� �Ÿ��� �ָ�(0.05f �ʰ�) �ִϸ��̼� �� ����, Ÿ�̸� �ʱ�ȭ
            if (Vector3.Distance(transform.position, destPos) > 0.05f)
            {
                anim.SetBool("isSitting", false);
                anim.SetBool("isMoving", true);
            }


            // Ŭ���� �ݶ��̴��� Floor�̰� �����̴� ���̸� ���⼳��, ������ �ٶ󺸰���
            if (hit.collider.name == "Floor" && anim.GetBool("isMoving"))
            {
                dir = destPos - transform.position;
                transform.LookAt(destPos);
            }
        }
    }

    void CatMove()
    {
        // �̵�
        if(anim.GetBool("isMoving"))
            transform.position += dir.normalized * catSpeed;

        // �������� �����ϸ� (0.01f ����) �̵� ����
        if (Vector3.Distance(transform.position, destPos) <= 0.01f)
        {
            anim.SetBool("isMoving", false);
            //sitTimer = 0f;
        }
    }

    void SitAnimChange()
    {
        anim.SetBool("isSitting", true);
    }
}