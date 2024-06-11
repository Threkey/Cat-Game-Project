using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    Button btnAdopt, btnCollection, btnPlay, btnOption;

    // Start is called before the first frame update
    void Start()
    {
        btnAdopt = GameObject.Find("Button_Adopt").GetComponent<Button>();
        btnCollection = GameObject.Find("Button_Collection").GetComponent<Button>();

        btnAdopt.onClick.AddListener(LoadAdoptScene);
        btnCollection.onClick.AddListener(LoadCollectionScene);
    }

    void LoadAdoptScene()
    {
        SceneManager.LoadScene("AdoptionScene");
    }

    void LoadCollectionScene()
    {
        SceneManager.LoadScene("CollectionScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
