using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > 0.5f)
        {
            Receive.messageReceived = true;
        }
        else
        {
            Receive.messageReceived = false;
        } 
    }
}
