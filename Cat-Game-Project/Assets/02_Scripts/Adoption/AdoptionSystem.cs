using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AdoptionSystem : MonoBehaviour
{
    const int maxIndex = 4;
    const int cost = 10;

    GameManager gm;
    public GameObject[] cats = new GameObject[4];
    public Sprite[] catSprites = new Sprite[4];

    Vector3 spritePos = new Vector3(-170f, 0f, 0f);
    Vector2 spriteSize = new Vector2(200f, 200f);
    Button btnAdopt, btnBack, btnAdoptAgain, btnResultBack;
    GameObject panelResult, panelResultBackPanel;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        panelResultBackPanel = GameObject.Find("Canvas").transform.Find("Panel_ResultBackPanel").gameObject;
        panelResult = panelResultBackPanel.transform.Find("Panel_Result").gameObject;
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnBack = GameObject.Find("Button_Back").GetComponent<Button>();
        btnResultBack = panelResult.transform.Find("Button_ResultBack").GetComponent <Button>();
        btnAdoptAgain = panelResult.transform.Find("Button_AdoptAgain").GetComponent <Button>();

        btnAdopt.onClick.AddListener(Adopt);
        btnBack.onClick.AddListener(LoadLobbyScene);
        btnAdoptAgain.onClick.AddListener(AdoptAgain);
        btnResultBack.onClick.AddListener(DestroyResultBackPanel);
    }

    private void Update()
    {
        if(gm.GetMoney() >= cost)
        {
            btnAdopt.interactable = true;
            btnAdoptAgain.interactable = true;
        }
        else if(gm.GetMoney() < cost)
        {
            btnAdopt.interactable = false;
            btnAdoptAgain.interactable = false;
        }

    }

    //--------------------ÇÔ¼ö----------------------

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void Adopt()
    {
        panelResultBackPanel.SetActive(true);

        int index = Random.Range(0, cats.Length);
        GameObject tmp = cats[index];
        Sprite tmpSprite = catSprites[index];
        Image image = new GameObject("Image").AddComponent<Image>();

        image.sprite = tmpSprite;
        image.transform.SetParent(panelResult.transform);
        image.rectTransform.anchoredPosition = spritePos;
        image.rectTransform.sizeDelta = spriteSize;

        gm.AddCat(tmp, tmpSprite);

        gm.AddMoney(-cost);
    }

    void AdoptAgain()
    {
        Destroy(panelResult.transform.Find("Image").gameObject);
        panelResultBackPanel.SetActive(false);

        Adopt();
    }

    void DestroyResultBackPanel()
    {
        panelResultBackPanel.SetActive(false);
    }
}
