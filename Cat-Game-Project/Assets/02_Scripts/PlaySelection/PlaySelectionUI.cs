using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySelectionUI : MonoBehaviour
{
    GameManager gm;

    public Sprite buttonImage;

    GameObject canvas, panelCatSelect;
    RectTransform rectTransform;
    Image image, catImage;
    Button btnCat;

    Vector3 buttonPos = new Vector3(-250f, 80f, 0);

    enum GameMode
    {
        Hunting,
        Sleeping,
        Running
    }

    GameMode mode;

    GameObject content;

    Button btnHunting, btnSleeping, btnRunning, btnBack;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        canvas = GameObject.Find("Canvas");
        panelCatSelect = canvas.transform.Find("Panel_CatSelect").gameObject;

        btnHunting = GameObject.Find("Button_Hunting").GetComponent<Button>();
        btnSleeping = GameObject.Find("Button_Sleeping").GetComponent <Button>();
        btnRunning = GameObject.Find("Button_Running").GetComponent< Button>();
        btnBack = GameObject.Find("Button_Back").GetComponent<Button>();

        btnBack.onClick.AddListener(LoadLobbyScene);
        btnSleeping.onClick.AddListener(SelectSleeping);
        btnHunting.onClick.AddListener(SelectHunting);
        btnRunning.onClick.AddListener(SelectRunning);

        content = panelCatSelect.transform.Find("Scroll View").Find("Viewport").Find("Content").gameObject;

        AddButtons();
    }

    void AddButtons()
    {
        for (int i = 0; i < gm.GetCatsCount(); i++)
        {
            // 버튼 생성, 컴포넌트 추가
            btnCat = new GameObject("Button_" + i).AddComponent<Button>();
            image = btnCat.AddComponent<Image>();
            rectTransform = btnCat.GetComponent<RectTransform>();
            catImage = new GameObject("Image").AddComponent<Image>();
            catImage.transform.SetParent(btnCat.transform);

            // 컴포넌트 속성 설정
            image.sprite = buttonImage;
            image.type = Image.Type.Sliced;
            btnCat.transform.SetParent(content.transform);
            rectTransform.anchoredPosition = buttonPos;
            catImage.sprite = gm.GetCatSprite(i);
            catImage.type = Image.Type.Filled;
            catImage.rectTransform.sizeDelta = new Vector2(90f, 90f);

            switch (mode)
            {
                case GameMode.Hunting:
                    {
                        btnCat.onClick.AddListener(LoadHuntingScene);
                        break;
                    }
                case GameMode.Running:
                    {
                        btnCat.onClick.AddListener(LoadRunningScene);
                        break;
                    }
                case GameMode.Sleeping:
                    {
                        btnCat.onClick.AddListener(LoadSleepingScene);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    void SelectHunting()
    {
        mode = GameMode.Hunting;
        PopupCatSelectPanel();
    }

    void SelectRunning()
    {
        mode = GameMode.Running;
        PopupCatSelectPanel();
    }
    void SelectSleeping()
    {
        mode = GameMode.Sleeping;
        PopupCatSelectPanel();
    }

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void LoadHuntingScene()
    {
        SceneManager.LoadScene("HuntingScene");
    }

    void LoadSleepingScene()
    {
        SceneManager.LoadScene("SleepingScene");
    }

    void LoadRunningScene()
    {
        SceneManager.LoadScene("RunningScene");
    }

    void PopupCatSelectPanel()
    {
        panelCatSelect.SetActive(true);
    }
}
