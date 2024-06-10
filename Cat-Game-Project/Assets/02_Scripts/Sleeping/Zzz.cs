using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zzz : MonoBehaviour
{
    Vector3 move;
    Color color;
    TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Canvas2").Find("Text").GetComponent<TextMeshProUGUI>();
        move = new Vector3(1f, 0.5f, 0f);
        color = new Vector4(0f, 0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * Time.deltaTime);
        text.color -= color * Time.deltaTime;
        text.fontSize += 0.5f;

        if (text.color.a <= 0f)
            Destroy(gameObject);
    }
}
