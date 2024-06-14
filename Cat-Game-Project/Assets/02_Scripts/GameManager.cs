//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject defaultGoCat;
    public Sprite defaultCatSprite;

    class Cat
    {
        GameObject goCat;      // 고양이 프리팹
        int friendship = 0;         // 호감도
        string name;                  // 고양이 이름
        Sprite sprite;                  // 고양이 이미지 스프라이트

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

        public int GetFriendship()
        {
            return friendship;
        }

        public void AddFriendship(int friendship)
        {
            this.friendship += friendship;
        }
    }

    private int money = 0;                                          // 재화

    private Vector3 clickPos;                                     // 클릭(터치 위치)

    private List<Cat> cats = new List<Cat>();            // 본인이 입양한 고양이 리스트


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);

        DontDestroyOnLoad(Instance);

        AddCat(defaultGoCat, defaultCatSprite);

        PlayerPrefs.SetInt("LobbyCatIndex", 0);
        PlayerPrefs.SetInt("PlayCatIndex", 0);
    }


    // Get함수

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

    public GameObject GetGoCat(int index)
    {
        GameObject tmp = cats[index].GetGoCat();
        return tmp;
    }

    public int GetFriendship(int index)
    {
        int tmp = cats[index].GetFriendship();
        return tmp;
    }



    // Set함수


    public void SetMoney(int money)
    {
        this.money = money;
    }

    public void SetClickPos(Vector3 position)
    {
        this.clickPos = position;
    }


    // Add함수

    public void AddCat(GameObject goCat, Sprite sprite)
    {
        Cat cat = new Cat(goCat, goCat.name, sprite);
        cats.Add(cat);
        Debug.Log(goCat.name);
        Debug.Log(cats.Count);
    }

    public void AddMoney(int money)
    {
        Debug.Log("Money");
        this.money += money;
    }

    public void AddFriendship(int  friendship, int index)
    {
        Debug.Log("Friendship");
        cats[index].AddFriendship(friendship);
    }

}
