using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SleepingControll : MonoBehaviour
{
    GameManager gm;

    GameObject cat, stick;

    TextMeshProUGUI textTimer, textScore, textCountdown, textResultScore, textResultFriendship, textMoney;
    public GameObject panelResult, panelReady;

    Button btnOk;

    Vector3 catPos = new Vector3(-1f, 0f, 0f);
    Vector3 catRot = new Vector3(0f, 90f, 0f);
    Quaternion catQuat;

    public float speed = 0.01f;
    public float time = 30f;
    int friendship = 0;
    public int score = 0;
    int money;
    int countdown;

    bool isUpdated = false;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        catQuat = Quaternion.Euler(catRot);

        stick = GameObject.Find("Stick");
        textTimer = GameObject.Find("Text_Timer").GetComponent<TextMeshProUGUI>();
        textScore = GameObject.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        textCountdown = GameObject.Find("Text_Countdown").GetComponent<TextMeshProUGUI>();
        panelResult = GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject;
        panelReady = GameObject.Find("Canvas").transform.Find("Panel_Ready").gameObject;
        textResultScore = panelResult.transform.Find("Text_ResultScore").gameObject.GetComponent<TextMeshProUGUI>();
        textResultFriendship = panelResult.transform.Find("Text_ResultFriendship").gameObject.GetComponent<TextMeshProUGUI>();
        textMoney = panelResult.transform.Find("Text_Money").gameObject.GetComponent <TextMeshProUGUI>();
        btnOk = panelResult.transform.Find("Button_Ok").GetComponent <Button>();

        btnOk.onClick.AddListener(LoadLobbyScene);

        StartCoroutine(coCountdown());

        cat = Instantiate(gm.GetGoCat(PlayerPrefs.GetInt("PlayCatIndex")), catPos, catQuat);
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
        else if (panelResult.activeSelf == true && !isUpdated)
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
        {
            time = 30f;
            textCountdown.text = "Go!";
        }

        else if (countdown == -1)
        {
            textCountdown.gameObject.SetActive(false);
            panelReady.SetActive(false);
            
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
        money = score;
        textMoney.text = "Money: " + money;

        gm.AddMoney(money);
        gm.AddFriendship(friendship, PlayerPrefs.GetInt("PlayCatIndex"));

        isUpdated = true;
    }

    void Judge()
    {
        
    }

    // 스틱이 speed만큼 움직임, bar의 끝에 닿을 때마다 방향 전환
    void MoveStick()
    {
        if (stick.transform.position.x < -1.5f)
        {
            speed = -speed;
        }
        else if (stick.transform.position.x > 1.5f)
        {
            speed = -speed;
        }

        stick.transform.Translate(speed, 0f, 0f);
    }

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
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