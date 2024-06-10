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
        // ���� ī��Ʈ�ٿ�
        UpdateTextCountdown();

        // ���� ī��Ʈ�ٿ�� ���â�� ��Ȱ��ȭ��
        if (textCountdown.gameObject.activeSelf == false && panelResult.activeSelf == false)
        {
            // Ÿ�̸� ����, Ÿ�̸ӿ� ���� �ؽ�Ʈ ������Ʈ
            time -= Time.deltaTime;
            UpdateTextTimer();
            UpdateTextScore();
        }

        // ���â�� ������ Ÿ�̸Ӷ� �ؽ�Ʈ ������Ʈ�� ���߰� ���â ���� ������Ʈ
        else if(panelResult.activeSelf == true)
        {
            UpdateResult();
        }

        // Ÿ�̸Ӱ� ������ ���â Ȱ��ȭ
        if(time <= 0f)
        {
            panelResult.SetActive(true);
        }

        // Ÿ���� ������ Ÿ�� ����
        if (GameObject.FindGameObjectWithTag("Target") == null)
            TargetSpawn();
    }

    //--------------------------------------------�Լ�---------------------------------------------


    // ���� ��ġ�� target����
    void TargetSpawn()
    {
        spawnPos = new Vector3(Random.Range(-0.7f, 0.7f), 0.06f, Random.Range(-0.4f, 0.4f));
        Instantiate(target, spawnPos, Quaternion.identity);
    }

    // Ÿ�̸� �ؽ�Ʈ ������Ʈ
    void UpdateTextTimer()
    {
        textTimer.text = "Timer: " + time.ToString("0.00");
    }

    // ���� �ؽ�Ʈ ������Ʈ
    void UpdateTextScore()
    {
        textScore.text = "Score: " + score;
    }

    // ī��Ʈ�ٿ� �ؽ�Ʈ ������Ʈ, ī��Ʈ�ٿ��� ������ ī��Ʈ�ٿ� �ؽ�Ʈ ��Ȱ��ȭ��  Ÿ�̸� 30�ʷ� �ʱ�ȭ
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

    // ��� �ؽ�Ʈ ������Ʈ
    void UpdateResult()
    {
        textResultScore.text = "Score: " + score;
        friendship = score * 2;
        textResultFriendship.text = "Friendship: " + friendship;
    }

    // ī��Ʈ�ٿ� �ڷ�ƾ
    IEnumerator coCountdown()
    {
        for(countdown = 3; countdown >= -1; countdown--)
        {
            Debug.Log(countdown);
            yield return new WaitForSeconds(1f);
        }
    }
}