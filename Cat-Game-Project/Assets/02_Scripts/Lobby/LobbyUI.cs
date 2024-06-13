using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LobbyUI : MonoBehaviour
{
    GameManager gm;

    Button btnAdopt, btnCollection, btnPlay, btnOption, btnOptionBack, btnQuitGame;
    TextMeshProUGUI textMoney, textFriendship;
    GameObject panelOptionBackPanel;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        panelOptionBackPanel = GameObject.Find("Canvas").transform.Find("Panel_OptionBackPanel").gameObject;
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnCollection = GameObject.Find("Button_Collection").GetComponent<Button>();
        btnPlay = GameObject.Find("Button_Play").GetComponent <Button>();
        btnOption = GameObject.Find("Button_Option").GetComponent<Button>();
        btnOptionBack = panelOptionBackPanel.transform.Find("Panel_Option").Find("Button_OptionBack").GetComponent<Button>();
        btnQuitGame = panelOptionBackPanel.transform.Find("Panel_Option").Find("Button_QuitGame").GetComponent<Button>();
        textMoney = GameObject.Find("Text_Money").GetComponent<TextMeshProUGUI>();
        textFriendship = GameObject.Find("Text_Friendship").GetComponent<TextMeshProUGUI>();

        btnAdopt.onClick.AddListener(LoadAdoptScene);
        btnCollection.onClick.AddListener(LoadCollectionScene);
        btnPlay.onClick.AddListener(LoadPlaySelectionScene);
        btnOption.onClick.AddListener(PopupOptionUI);
        btnOptionBack.onClick.AddListener(CloseOptionUI);
        btnQuitGame.onClick.AddListener(QuitGame);

        UpdateTextMoney();
        UpdateTextFriendship();
        Instantiate(gm.GetGoCat(PlayerPrefs.GetInt("LobbyCatIndex")));
    }

    void UpdateTextMoney()
    {
        textMoney.text = "Money : " + gm.GetMoney();
    }

    void UpdateTextFriendship()
    {
        textFriendship.text = "Friendship : " + gm.GetFriendship(PlayerPrefs.GetInt("LobbyCatIndex"));
    }

    void LoadAdoptScene()
    {
        SceneManager.LoadScene("AdoptionScene");
    }

    void LoadCollectionScene()
    {
        SceneManager.LoadScene("CollectionScene");
    }

    void LoadPlaySelectionScene()
    {
        SceneManager.LoadScene("PlaySelectionScene");
    }

    void PopupOptionUI()
    {
        panelOptionBackPanel.SetActive(true);
    }

    void CloseOptionUI()
    {
        panelOptionBackPanel.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
