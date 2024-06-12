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
            // ��ư ����, ������Ʈ �߰�
            btnCat = new GameObject("Button_" + i).AddComponent<Button>();
            image = btnCat.AddComponent<Image>();
            rectTransform = btnCat.GetComponent<RectTransform>();
            catImage = new GameObject("Image").AddComponent<Image>();
            catImage.transform.SetParent(btnCat.transform);

            // ��ư ��ġ
            // �̷� ��ģ Grid Layout Group, Content Size Fitter��� �ʹ� ���� ������Ʈ�� �־��ٴ�
            /*
            if(i % 4 == 0)
            {
                buttonPos.x = -250f;
                if(i != 0)
                {
                    // ��ũ�Ѻ� ������ ���� �ø�
                    
                    Vector2 contentRect = content.GetComponent<RectTransform>().offsetMin;
                    contentRect.y -= 120f;
                    content.GetComponent<RectTransform>().offsetMin = contentRect;
                    
                    buttonPos.y -= 120f;
                }

            }
            else
            {
                buttonPos.x += 150f;
            }
            */

            // ������Ʈ �Ӽ� ����
            image.sprite = buttonImage;
            image.type = Image.Type.Sliced;
            btnCat.transform.SetParent(content.transform);
            rectTransform.anchoredPosition = buttonPos;
            catImage.sprite = gm.GetCatSprite(i);
            catImage.type = Image.Type.Filled;
            catImage.rectTransform.sizeDelta = new Vector2(90f, 90f);
        }
    }
}
