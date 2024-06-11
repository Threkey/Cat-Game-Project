using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AdoptionSystem : MonoBehaviour
{
    const int maxIndex = 4;

    GameManager gm;
    public GameObject[] cats = new GameObject[4];
    public Sprite[] catSprites = new Sprite[4];

    Vector3 catPos = new Vector3(-5f, -1.5f, 0);
    Button btnAdopt, btnBack;
    GameObject panelResult;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnBack = GameObject.Find("Button_Back").GetComponent<Button>();

        btnAdopt.onClick.AddListener(Adopt);
        btnBack.onClick.AddListener(LoadLobbyScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void Adopt()
    {
        int index = Random.Range(0, cats.Length);
        GameObject tmp = cats[index];
        Sprite tmpSprite = catSprites[index];

        gm.AddCat(tmp, tmpSprite);

        GameObject.Find("Canvas").transform.Find("Panel_Result").gameObject.SetActive(true);

        /*
        tmp = Instantiate(tmp).gameObject;
        tmp.transform.localScale = new Vector3(30f, 30f, 30f);
        tmp.transform.SetParent(panelResult.transform, false);
        */
    }
}
