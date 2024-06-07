using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class LobbyCatMove : MonoBehaviour
{
    public Animator anim;
    float catSpeed = 0.001f;
    float sitTimer = 0f, sitWaitTime = 2f;          // �ɱ� Ÿ�̸�, ���� �� ������ �ð�

    Vector3 destPos;            // ������
    Vector3 dir;                    // ����

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
                sitTimer = 0f;
                anim.SetBool("isSitting", false);
                anim.SetBool("isMoving", true);
            }


            // Ŭ���� �ݶ��̴��� Floor�̰� �����̴� ���̸� ���⼳��, ������ �ٶ󺸰���
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
        // �̵�
        if(anim.GetBool("isMoving"))
            transform.position += dir.normalized * catSpeed;

        // �������� �����ϸ� (0.05f ����) �̵� ����
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