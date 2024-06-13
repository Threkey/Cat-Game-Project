using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stick : MonoBehaviour
{
    SleepingControll system;
    Rigidbody rb;
    GameObject cat;
    public GameObject Zzz;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        system = GameObject.Find("GameSystem").GetComponent<SleepingControll>();
        rb = GetComponent<Rigidbody>();
        cat = GameObject.FindWithTag("Cat");
        StartCoroutine(coStopStick());
    }

    // Update is called once per frame
    void Update()
    {
        if(system.speed == 0f)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic= true;
        }
    }

    IEnumerator coStopStick()
    {
        while (system.time > 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                system.score--;
                Debug.Log("click");
                speed = system.speed;
                system.speed = 0f;
                yield return new WaitForSeconds(0.5f);
                system.speed = speed;
            }
            else
                yield return null;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CorrectZone")
        {
            Debug.Log("correct");
            system.score += 2;
            Instantiate(Zzz);
        }
    }
}