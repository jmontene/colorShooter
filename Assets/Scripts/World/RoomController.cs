using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    Room[,] rooms;
    public int posX, posY;

    public Camera roomCamera; 

    public List<Room> testRooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = new Room[3,4];

        // Add rooms to array
        foreach (Room room in testRooms)
        {
            var x = room.posX;
            var y = room.posY;
            rooms[x,y] = room;
        }

    }

    public void MoveUp(){
        posY++;
        var nextRoom = rooms[posX, posY];
        Camera.main.transform.position = nextRoom.transform.position;
        //MovePlayer
        
        var player = GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, nextRoom.doorDown.transform.position.y+2.5f, 1);
    }

    public void MoveDown(){
        posY--;
        Debug.Log("pos:"+posX+"-"+posY);
        var nextRoom = rooms[posX, posY];
        Camera.main.transform.position = nextRoom.transform.position;

        Debug.Log("moving down");

        var player = GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, nextRoom.doorUp.transform.position.y-0.5f, 1);
    }

    public void MoveLeft(){
        posX--;
        var nextRoom = rooms[posX, posY];
        Camera.main.transform.position = nextRoom.transform.position;

        var player = GameObject.Find("Player").transform.position = new Vector3(nextRoom.doorRight.transform.position.x-1.75f, GameObject.Find("Player").transform.position.y, 1);
    }

    public void MoveRight(){
        posX++;
        var nextRoom = rooms[posX, posY];
        Camera.main.transform.position = nextRoom.transform.position;

        var player = GameObject.Find("Player").transform.position = new Vector3(nextRoom.doorLeft.transform.position.x+1.75f, GameObject.Find("Player").transform.position.y, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
