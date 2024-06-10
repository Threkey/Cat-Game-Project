using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningSystem : MonoBehaviour
{
    Button btnTouch;

    float speed = 0f, maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        btnTouch = GameObject.Find("Button_Touch").GetComponent<Button>();
        btnTouch.onClick.AddListener(IncreaseSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseSpeed();
    }

    void DecreaseSpeed()
    {
        if (speed > 0)
            speed -= 0.1f;
        else if(speed < 0)
            speed = 0;
    }

    void IncreaseSpeed()
    {
        if (speed < maxSpeed)
            speed += 0.1f;
    }
}
