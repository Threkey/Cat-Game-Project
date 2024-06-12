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

    Button btnAdopt, btnCollection, btnPlay, btnOption, btnOptionBack;
    TextMeshProUGUI textMoney;
    GameObject panelOption;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        panelOption = GameObject.Find("Canvas").transform.Find("Panel_Option").gameObject;
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnCollection = GameObject.Find("Button_Collection").GetComponent<Button>();
        btnPlay = GameObject.Find("Button_Play").GetComponent <Button>();
        btnOption = GameObject.Find("Button_Option").GetComponent<Button>();
        btnOptionBack = panelOption.transform.Find("Button_OptionBack").GetComponent<Button>();
        textMoney = GameObject.Find("Text_Money").GetComponent<TextMeshProUGUI>();

        btnAdopt.onClick.AddListener(LoadAdoptScene);
        btnCollection.onClick.AddListener(LoadCollectionScene);
        btnPlay.onClick.AddListener(LoadPlaySelectionScene);
        btnOption.onClick.AddListener(PopupOptionUI);
        btnOptionBack.onClick.AddListener(CloseOptionUI);

        UpdateTextMoney();
    }

    void UpdateTextMoney()
    {
        textMoney.text = "Money : " + gm.GetMoney();
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
        panelOption.SetActive(true);
    }

    void CloseOptionUI()
    {
        panelOption.SetActive(false);
    }
}
