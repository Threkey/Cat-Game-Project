using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningSystem : MonoBehaviour
{
    GameObject wheel;
    Button btnTouch;

    float speed = 0f, maxSpeed = 10f;

    

    // Start is called before the first frame update
    void Start()
    {
        wheel = GameObject.Find("HamsterWheel");

        btnTouch = GameObject.Find("Button_Touch").GetComponent<Button>();
        btnTouch.onClick.AddListener(IncreaseSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        

        //DecreaseSpeed();
        RollWheel();
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
            speed += 1f;
    }

    void RollWheel()
    {

    }
}