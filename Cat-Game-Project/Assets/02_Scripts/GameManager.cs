using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject defaultGoCat;
    public Sprite defaultCatSprite;

    class Cat
    {
        GameObject goCat;      // ����� ������
        int friendship = 0;         // ȣ����
        string name;                  // ����� �̸�
        Sprite sprite;                  // ����� �̹��� ��������Ʈ

        public Cat() { }
        public Cat(GameObject goCat, string name, Sprite sprite)
        {
            this.goCat = goCat;
            this.name = name;
            this.sprite = sprite;
            this.friendship = 0;
        }

        public GameObject GetGoCat()
        {
            return goCat;
        }

        public Sprite GetSprite()
        {
            return sprite;
        }
    }

    private int money = 0;                                          // ��ȭ

    private Vector3 clickPos;                                     // Ŭ��(��ġ ��ġ)

    private List<Cat> cats = new List<Cat>();            // ������ �Ծ��� ����� ����Ʈ


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(Instance);

        DontDestroyOnLoad(Instance);

        AddCat(defaultGoCat, defaultCatSprite);
    }


    // Get�Լ�

    public int GetMoney()
    {
        return money;
    }

    public Vector3 GetClickPos()
    {
        return clickPos;
    }

    public int GetCatsCount()
    {
        return cats.Count;
    }

    public Sprite GetCatSprite(int index)
    {
        if (cats[index] != null)
            return cats[index].GetSprite();
        else return null;
    }



    // Set�Լ�


    public void SetMoney(int money)
    {
        this.money = money;
    }

    public void SetClickPos(Vector3 position)
    {
        this.clickPos = position;
    }


    // Add�Լ�

    public void AddCat(GameObject goCat, Sprite sprite)
    {
        Cat cat = new Cat(goCat, goCat.name, sprite);
        cats.Add(cat);
        Debug.Log(goCat.name);
        Debug.Log(cats.Count);
    }
}
