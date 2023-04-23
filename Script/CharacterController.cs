using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.D))
     {
            transform.Translate(speed * Time.deltaTime,0,0);
     } 
     if(Input.GetKey(KeyCode.A)) 
     {
            transform.Translate(speed* Time.deltaTime * -1,0,0);
     }
     if(Input.GetKey(KeyCode.W)) 
     {
            transform.Translate(0,speed * Time.deltaTime,0,0);    
     }
     if (Input.GetKey(KeyCode.S))
     {
            transform.Translate(0,speed * Time.deltaTime * -1,0, 0);     
     }
    }
}
