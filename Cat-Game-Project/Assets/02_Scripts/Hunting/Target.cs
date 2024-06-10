using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    HuntingControll system;
    private void Start()
    {
        system = GameObject.Find("GameSystem").GetComponent<HuntingControll>();
    }
    private void OnCollisionStay(Collision collision)
    {

        if(collision.gameObject.tag == "Cat")
        {
            system.score++;
            Destroy(this.gameObject);
        }
    }
}
