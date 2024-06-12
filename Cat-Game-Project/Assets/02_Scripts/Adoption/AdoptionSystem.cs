using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AdoptionSystem : MonoBehaviour
{
    const int maxIndex = 4;

    GameManager gm;
    public GameObject[] cats = new GameObject[4];
    public Sprite[] catSprites = new Sprite[4];

    Vector3 spritePos = new Vector3(-170f, 0f, 0f);
    Vector2 spriteSize = new Vector2(200f, 200f);
    Button btnAdopt, btnBack, btnAdoptAgain;
    GameObject panelResult;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        panelResult = GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject;
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnBack = GameObject.Find("Button_Back").GetComponent<Button>();
        btnAdoptAgain = panelResult.transform.Find("Button_AdoptAgain").GetComponent <Button>();

        btnAdopt.onClick.AddListener(Adopt);
        btnBack.onClick.AddListener(LoadLobbyScene);
        btnAdoptAgain.onClick.AddListener(AdoptAgain);
    }

    //--------------------ÇÔ¼ö----------------------

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void Adopt()
    {
        panelResult.SetActive(true);

        int index = Random.Range(0, cats.Length);
        GameObject tmp = cats[index];
        Sprite tmpSprite = catSprites[index];
        Image image = new GameObject("Image").AddComponent<Image>();

        image.sprite = tmpSprite;
        image.transform.SetParent(panelResult.transform);
        image.rectTransform.anchoredPosition = spritePos;
        image.rectTransform.sizeDelta = spriteSize;

        gm.AddCat(tmp, tmpSprite);
    }

    void AdoptAgain()
    {
        Destroy(panelResult.transform.Find("Image").gameObject);
        panelResult.SetActive(false);

        Adopt();
    }
}
