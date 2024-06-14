using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionSystem : MonoBehaviour
{
    GameManager gm;

    public Sprite buttonImage;

    GameObject canvas;
    RectTransform rectTransform;
    Image image, catImage;
    Button btnCat, btnBack;

    Vector3 buttonPos = new Vector3(-250f, 80f, 0);

    GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        content = GameObject.Find("Content");

        btnBack = GameObject.Find("Button_Back").GetComponent<Button>();
        btnBack.onClick.AddListener(LoadLobbyScene);

        AddButtons();
    }

    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void AddButtons()
    {
        for(int i = 0; i < gm.GetCatsCount(); i++)
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
            rectTransform.localScale = Vector3.one;

            int index = i;
            btnCat.onClick.AddListener(delegate { SelectCat(index); });
        }
    }

    void SelectCat(int index)
    {
        PlayerPrefs.SetInt("LobbyCatIndex", index);
        SceneManager.LoadScene("LobbyScene");
    }
}
