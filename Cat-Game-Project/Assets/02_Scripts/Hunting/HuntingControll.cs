using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HuntingControll : MonoBehaviour
{
    public GameObject target;

    TextMeshProUGUI textTimer, textScore, textCountdown, textResultScore, textResultFriendship;
    GameObject panelResult;

    Vector3 spawnPos;

    float time = 30f;
    int friendship = 0;
    public int score = 0;
    int countdown;
    // Start is called before the first frame update
    void Start()
    {
        textTimer = GameObject.Find("Text_Timer").GetComponent<TextMeshProUGUI>();
        textScore = GameObject.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        textCountdown = GameObject.Find("Text_Countdown").GetComponent <TextMeshProUGUI>();
        panelResult = GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject;
        textResultScore = panelResult.transform.Find("Text_ResultScore").gameObject.GetComponent<TextMeshProUGUI>();
        textResultFriendship = panelResult.transform.Find("Text_ResultFriendship").gameObject.GetComponent <TextMeshProUGUI>();

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
            // 타이머 시작, 타이머와 점수 텍스트 업데이트
            time -= Time.deltaTime;
            UpdateTextTimer();
            UpdateTextScore();
        }

        // 결과창이 나오면 타이머랑 텍스트 업데이트를 멈추고 결과창 내용 업데이트
        else if(panelResult.activeSelf == true)
        {
            UpdateResult();
        }

        // 타이머가 끝나면 결과창 활성화
        if(time <= 0f)
        {
            panelResult.SetActive(true);
        }

        // 타겟이 없으면 타겟 생성
        if (GameObject.FindGameObjectWithTag("Target") == null)
            TargetSpawn();
    }

    //--------------------------------------------함수---------------------------------------------


    // 랜덤 위치에 target생성
    void TargetSpawn()
    {
        spawnPos = new Vector3(Random.Range(-0.7f, 0.7f), 0.06f, Random.Range(-0.4f, 0.4f));
        Instantiate(target, spawnPos, Quaternion.identity);
    }

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
        else if(countdown == -1)
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

    // 카운트다운 코루틴
    IEnumerator coCountdown()
    {
        for(countdown = 3; countdown >= -1; countdown--)
        {
            Debug.Log(countdown);
            yield return new WaitForSeconds(1f);
        }
    }
}