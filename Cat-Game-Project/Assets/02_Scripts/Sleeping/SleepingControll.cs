using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SleepingControll : MonoBehaviour
{
    GameObject stick, bar, zone;

    TextMeshProUGUI textTimer, textScore, textCountdown, textResultScore, textResultFriendship;
    GameObject panelResult;

    float speed = 0.01f;
    float time = 30f;
    int friendship = 0;
    public int score = 0;
    int countdown;


    // Start is called before the first frame update
    void Start()
    {
        stick = GameObject.Find("Stick");
        bar = GameObject.Find("Bar");
        zone = GameObject.Find("CorrectZone");

        textTimer = GameObject.Find("Text_Timer").GetComponent<TextMeshProUGUI>();
        textScore = GameObject.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        textCountdown = GameObject.Find("Text_Countdown").GetComponent<TextMeshProUGUI>();
        panelResult = GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject;
        textResultScore = panelResult.transform.Find("Text_ResultScore").gameObject.GetComponent<TextMeshProUGUI>();
        textResultFriendship = panelResult.transform.Find("Text_ResultFriendship").gameObject.GetComponent<TextMeshProUGUI>();

        StartCoroutine(coCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        // 시작 카운트다운
        UpdateTextCountdown();

        // 시작 카운트다운과 결과창이 비활성화면
        if (textCountdown.gameObject.activeSelf == false && panelResult.activeSelf == false)
        {
            // 타이머 시작, 타이머와 점수 텍스트 업데이트, 스틱 움직이기 시작
            time -= Time.deltaTime;
            UpdateTextTimer();
            UpdateTextScore();
            MoveStick();
        }

        // 결과창이 나오면 타이머랑 텍스트 업데이트를 멈추고 결과창 내용 업데이트
        else if (panelResult.activeSelf == true)
        {
            UpdateResult();
        }

        // 화면을 클릭하면 점수 판정
        if(Input.GetMouseButtonDown(0))
        {
            Judge();
        }

        // 타이머가 끝나면 결과창 활성화
        if (time <= 0f)
        {
            panelResult.SetActive(true);
        }

    }

    //--------------------------------------------함수---------------------------------------------


    // 타이머 텍스트 업데이트
    void UpdateTextTimer()
    {
        textTimer.text = "Timer: " + time.ToString("0.00");
    }

    // 점수 텍스트 업데이트
    void UpdateTextScore()
    {
        textScore.text = "Score: " + score;
    }

    // 카운트다운 텍스트 업데이트, 카운트다운이 끝나면 카운트다운 텍스트 비활성화와  타이머 30초로 초기화
    void UpdateTextCountdown()
    {
        if (countdown == 0)
            textCountdown.text = "Go!";
        else if (countdown == -1)
        {
            textCountdown.gameObject.SetActive(false);
            time = 30f;
        }
        else
            textCountdown.text = countdown.ToString();
    }

    // 결과 텍스트 업데이트
    void UpdateResult()
    {
        textResultScore.text = "Score: " + score;
        friendship = score * 2;
        textResultFriendship.text = "Friendship: " + friendship;
    }

    // 스틱이 speed만큼 움직임, bar의 끝에 닿을 때마다 방향 전환
    void MoveStick()
    {
        if(stick.transform.position.x < -1.5f)
        {
            speed = -speed;
        }
        else if(stick.transform.position.x > 1.5f)
        {
            speed = -speed;
        }

        stick.transform.Translate(speed, 0f, 0f);
    }

    void Judge()
    {
        
    }


    // 카운트다운 코루틴
    IEnumerator coCountdown()
    {
        for (countdown = 3; countdown >= -1; countdown--)
        {
            Debug.Log(countdown);
            yield return new WaitForSeconds(1f);
        }
    }
}