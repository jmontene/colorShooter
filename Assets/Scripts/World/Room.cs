using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int posX, posY;
    public bool hasDoorUp, hasDoorDown, hasDoorLeft, hasDoorRight;
    public GameObject roomGrid;

    public GameObject doorUp, doorDown, doorLeft, doorRight;

    // start, normal, boss
    public string roomType;

    void Initialize(string roomType, bool down, bool left, bool right, bool up){
        this.roomType = roomType; 
        SetDoors(down, left, right, up);
        DrawDoors();
    }

    void SetDoors(bool down, bool left, bool right, bool up){
        hasDoorDown = down;
        hasDoorLeft = left;
        hasDoorRight = right;
        hasDoorUp = up;
    }


    //TODO Method to spawn enemies and boss

    void DrawDoors(){
        if (!hasDoorDown){
            doorDown.gameObject.SetActive(false);
        }
        if (!hasDoorLeft){
            doorLeft.gameObject.SetActive(false);
        }
        if (!hasDoorRight){
            doorRight.gameObject.SetActive(false);
        }
        if (!hasDoorUp){
            doorUp.gameObject.SetActive(false);
        }
    }

}
