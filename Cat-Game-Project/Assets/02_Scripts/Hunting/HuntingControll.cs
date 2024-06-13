using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class HuntingControll : MonoBehaviour
{
    GameManager gm;

    public GameObject target;

    TextMeshProUGUI textTimer, textScore, textCountdown, textResultScore, textResultFriendship, textMoney;
    GameObject panelResult, panelReady;

    Button btnOk;

    Vector3 spawnPos;

    bool isUpdated = false;

    float time = 30f;
    int friendship = 0;
    public int score = 0;
    int countdown;
    int money;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        textTimer = GameObject.Find("Text_Timer").GetComponent<TextMeshProUGUI>();
        textScore = GameObject.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        textCountdown = GameObject.Find("Text_Countdown").GetComponent <TextMeshProUGUI>();
        panelResult = GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject;
        panelReady = GameObject.Find("Canvas").transform.Find("Panel_Ready").gameObject;
        textResultScore = panelResult.transform.Find("Text_ResultScore").gameObject.GetComponent<TextMeshProUGUI>();
        textResultFriendship = panelResult.transform.Find("Text_ResultFriendship").gameObject.GetComponent <TextMeshProUGUI>();
        textMoney = panelResult.transform.Find("Text_Money").gameObject.GetComponent<TextMeshProUGUI>();
        btnOk = panelResult.transform.Find("Button_Ok").GetComponent<Button>();

        btnOk.onClick.AddListener(LoadLobbyScene);

        StartCoroutine(coCountdown());

        Instantiate(gm.GetGoCat(PlayerPrefs.GetInt("PlayCatIndex")));
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
        else if(panelResult.activeSelf == true && !isUpdated)
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
        {
            time = 30f;
            textCountdown.text = "Go!";
        }
        else if(countdown == -1)
        {
            textCountdown.gameObject.SetActive(false);
            panelReady.SetActive(false);
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
        money = score;
        textMoney.text = "Money: " + money;

        gm.AddMoney(money);
        gm.AddFriendship(friendship, PlayerPrefs.GetInt("PlayCatIndex"));

        isUpdated = true;
    }

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
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