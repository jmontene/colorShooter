using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    public int numRows;
    public int numColumns;
    public bool[,] takenRooms;
    private List<Vector2> availableRooms = new List<Vector2>();
    public List<Room> rooms;
    public Room roomPrefab;
    public int maxRooms; 

    public RoomController roomController;

    void Awake(){

        takenRooms = new bool[numColumns,numRows];
        int startX, startY;

        // //Random start room
        startX = Random.Range(0,numColumns);
        startY = Random.Range(0,numRows);
        var startRoom = new Vector2(startX,startY);
        availableRooms.Add(startRoom);


        // //Create all rooms using BFS
        int roomCount = 0;
        while (roomCount<=maxRooms){
            int randomIndex = Random.Range(0,availableRooms.Count);
            var currentRoom = availableRooms[randomIndex];
            availableRooms.RemoveAt(randomIndex);
            takenRooms[(int) currentRoom.x, (int) currentRoom.y] = true;
            var availableAdjacent=checkAdjacents((int) currentRoom.x, (int) currentRoom.y);
            availableRooms.AddRange(availableAdjacent);
            roomCount++;
        }

        //Create all rooms instances
        for (int x = 0; x < numColumns;x++){
            for (int y = 0; y < numRows;y++){
                if (takenRooms[x,y]){
                    var newRoom = CreateRoom(x,y);
                    rooms.Add(newRoom);
                }
            }
        }

        roomController.testRooms = rooms;
        roomController.posX = startX;
        roomController.posY = startY;
        roomController.numRows = numRows;
        roomController.numColumns = numColumns;

    }

    List<Vector2> checkAdjacents(int x, int y){
        //Check up
        List<Vector2> availableList = new List<Vector2>(); 
        if (y>0 && !takenRooms[x,y-1]){
            var roomPosition = new Vector2(x,y-1);
            availableList.Add(roomPosition);
        }
        //Check down
        if (y<numRows-1 && !takenRooms[x,y+1]){
            var roomPosition = new Vector2(x,y+1);
            availableList.Add(roomPosition);
        }
        //Check left
        if (x>0 && !takenRooms[x-1,y]){
            var roomPosition = new Vector2(x-1,y);
            availableList.Add(roomPosition);
        }
        //Check right
        if (x<numColumns-1 && !takenRooms[x+1,y]){
            var roomPosition = new Vector2(x+1,y);
            availableList.Add(roomPosition);
        }
        return availableList;
    }

    Room CreateRoom(int x, int y){
        Vector3 position = new Vector3(x * 20f, y*12f,0);
        Room newRoom = Instantiate(roomPrefab, position, Quaternion.identity);

        bool up,down,left,right;
        down = (y>0) && takenRooms[x,y-1];
        up = (y<numRows-1) && takenRooms[x,y+1];
        left = (x>0) && takenRooms[x-1,y];
        right =(x<numColumns-1) && takenRooms[x+1,y];

        newRoom.Initialize("normal",down,left, right,up);

        newRoom.posX = x;
        newRoom.posY = y;

        return newRoom;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
