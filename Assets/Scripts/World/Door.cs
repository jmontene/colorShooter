using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    // down left right up
    public string doorType;
    RoomController roomController; 

    private bool isTriggered = false; 

    void Awake()
    {
        roomController = GameObject.Find("RoomController").GetComponent<RoomController>();
        // roomController.MoveLeft();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D player)
     {

        if (player.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered door"+doorType);
            isTriggered = true;
            // Call controller
            if (doorType == "down"){
                roomController.MoveDown();
            }
            if (doorType == "up"){
                roomController.MoveUp();
            }
            if (doorType == "right"){
                roomController.MoveRight();
            }
            if (doorType == "left"){
                roomController.MoveLeft();
            }
        }
    }

    void OnTriggerExitD(Collider2D player)
     {
        if (player.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
}
