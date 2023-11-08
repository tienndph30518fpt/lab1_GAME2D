using UnityEngine;

public class Receive : MonoBehaviour
{
    public static bool messageReceived;
    private int numberOfMessages;
    private Renderer cubeRenderer;

    private void Start()
    {
        messageReceived = false;
        numberOfMessages = 0;
        cubeRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (messageReceived)
        {
            numberOfMessages++;
            Debug.Log("I have received " + numberOfMessages + " messages from the transmit script");

            if (numberOfMessages > 1000)
            {
                cubeRenderer.material.color = Color.green;
            }
            else if (numberOfMessages > 700)
            {
                cubeRenderer.material.color = Color.yellow;
            }
            else if (numberOfMessages > 500)
            {
                cubeRenderer.material.color = Color.red;
            }
        }
        else
        {
            Debug.Log("No messages received");
        }
    }
}