using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera FirstPersonCharacter;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");// + transform.position.x;
        float v = Input.GetAxis("Vertical");// + transform.position.y;
        float yConstant = transform.position.y;
        RaycastHit hit;


        enabled = false;
        //FirstPersonCharacter.transform.position += new Vector3(.1f * v, 0f, .1f * h); 
        //transform.position += new Vector3((-0.1f * v * (float)Math.Cos(FirstPersonCharacter.transform.eulerAngles.y))+ (-0.1f * h * (float)Math.Cos(FirstPersonCharacter.transform.eulerAngles.y - 90f)), 0f, (-0.1f * v * (float)Math.Sin(FirstPersonCharacter.transform.eulerAngles.y)) + (-0.1f * h * (float)Math.Sin(FirstPersonCharacter.transform.eulerAngles.y - 90f)));
        //transform.position += new Vector3((-0.1f * h * (float)Math.Cos(transform.rotation.y)), 0f, (-0.1f * h * (float)Math.Sin(transform.rotation.y)));
        //transform.position += transform.forward * (-0.1f * v);
        Vector3 targetPos = transform.position;
        targetPos += (FirstPersonCharacter.transform.forward * -.2f * h) + (FirstPersonCharacter.transform.right * .2f * v);
        targetPos.y = (float)yConstant;
        if (!Physics.Linecast(transform.position, targetPos, out hit))
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, Time.deltaTime);
        }
        
        enabled = true;
    }
}
