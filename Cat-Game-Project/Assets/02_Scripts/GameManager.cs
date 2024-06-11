using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    class Cat
    {
        GameObject goCat;
        int friendship = 0;
        string name;
        Sprite sprite;

        public Cat() { }
        public Cat(GameObject goCat, string name, Sprite sprite)
        {
            this.goCat = goCat;
            this.name = name;
            this.sprite = sprite;
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

    private int money = 0;

    private Vector3 clickPos;

    private List<Cat> cats = new List<Cat>();


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(Instance);

        DontDestroyOnLoad(Instance);
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
    }
}
