using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject catInLobby;
    private int money = 0;

    private Vector3 clickPos;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(Instance);

        DontDestroyOnLoad(Instance);
    }


    // Get함수
    GameObject GetCatInLobby()
    {
        if(catInLobby == null)
            return null;
        else return catInLobby;
    }

    int GetMoney()
    {
        return money;
    }

    Vector3 GetClickPos()
    {
        return clickPos;
    }



    // Set함수
    void SetCatInLobby(GameObject catInLobby)
    {
        this.catInLobby = catInLobby;
    }

    void SetMoney(int money)
    {
        this.money = money;
    }

    void SetClickPos(Vector3 position)
    {
        this.clickPos = position;
    }
}
