using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    SleepingControll system;
    Rigidbody rb;
    GameObject cat;
    public GameObject Zzz;
    // Start is called before the first frame update
    void Start()
    {
        system = GameObject.Find("GameSystem").GetComponent<SleepingControll>();
        rb = GetComponent<Rigidbody>();
        cat = GameObject.Find("cat01");         // ¹Ù²ã¾ßÇÔ
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic= true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CorrectZone")
        {
            system.score++;
            Instantiate(Zzz, cat.transform.position, Quaternion.identity);
        }

    }
}