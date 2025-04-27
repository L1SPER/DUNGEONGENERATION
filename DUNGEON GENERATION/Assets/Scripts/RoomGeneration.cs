using System.Collections.Generic;
using TreeEditor;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    #region Rooms
    [Header("Room Generation")]
    [SerializeField] private GameObject startRoom;
    [SerializeField] private Vector3 startRoomPosition;
    [SerializeField] private bool isStartRoomActive;
    [SerializeField] private GameObject[] room1x1Prefabs;
    [SerializeField] private bool is1x1RoomGenerated;
    [SerializeField] private GameObject[] room1x1DPrefabs;
    [SerializeField] private bool is1x1DRoomGenerated;
    [SerializeField] private GameObject[] room2x1Prefabs;
    [SerializeField] private bool is2x1RoomGenerated;
    [SerializeField] private GameObject[] room2x1YPrefabs;
    [SerializeField] private bool is2x1YRoomGenerated;
    [SerializeField] private GameObject[] room2x2Prefabs;
    [SerializeField] private bool is2x2RoomGenerated;
    [SerializeField] private GameObject[] room2x2DPrefabs;
    [SerializeField] private bool is2x2DRoomGenerated;
    [SerializeField] private GameObject[] room3x1Prefabs;
    [SerializeField] private bool is3x1RoomGenerated;
    [SerializeField] private GameObject[] room3x2YPrefabs;
    [SerializeField] private bool is3x2YRoomGenerated;
    [SerializeField] private GameObject[] room4x2Prefabs;
    [SerializeField] private bool is4x2RoomGenerated;
    [SerializeField] private GameObject[] room4x3APrefabs;
    [SerializeField] private bool is4x3ARoomGenerated;
    [SerializeField] private GameObject[] room5x5APrefabs;
    [SerializeField] private bool is5x5ARoomGenerated;
    #endregion

    [SerializeField] private Transform roomParent;
    private List<GameObject> rooms = new();
    private List<GameObject> roomsToBePlaced = new();
    [SerializeField] private int maxRooms;
    [SerializeField] private Grid grid;

    [SerializeField] private int maxRoomCount = 30;
    private List<RoomNode> roomNodes = new();
    private HashSet<RoomNode> visitedNodes = new HashSet<RoomNode>();
    [SerializeField] private int roomId=1;
    void Start()
    {
        AddToRoomList(room1x1Prefabs, is1x1RoomGenerated);
        AddToRoomList(room1x1DPrefabs, is1x1DRoomGenerated);
        AddToRoomList(room2x1Prefabs, is2x1RoomGenerated);
        AddToRoomList(room2x1YPrefabs, is2x1YRoomGenerated);
        AddToRoomList(room2x2Prefabs, is2x2RoomGenerated);
        AddToRoomList(room2x2DPrefabs, is2x2DRoomGenerated);
        AddToRoomList(room3x1Prefabs, is3x1RoomGenerated);
        AddToRoomList(room3x2YPrefabs, is3x2YRoomGenerated);
        AddToRoomList(room4x2Prefabs, is4x2RoomGenerated);
        AddToRoomList(room4x3APrefabs, is4x3ARoomGenerated);
        AddToRoomList(room5x5APrefabs, is5x5ARoomGenerated);


        grid = FindAnyObjectByType<Grid>();
        if (grid == null)
        {
            Debug.LogError("Grid not found in the scene.");
            return;
        }

        CreateDungeon();

        /* CreateRoom(startRoom, isStartRoomActive);
        CreateRoom(room1x1Prefabs, is1x1RoomGenerated); */
    }
    #region Before
    private void AddToRoomList(GameObject[] room, bool isActive)
    {
        if (!isActive) return;
        for (int i = 0; i < room.Length; i++)
        {
            roomsToBePlaced.Add(room[i]);
        }
    }
    /* private void CreateRoom(GameObject room, bool isActive)
    {
        if (!isActive) return;

        GameObject startRoom = Instantiate(room, grid.GetNode(startRoomPosition).worldPosition, Quaternion.identity, roomParent);
        rooms.Add(startRoom);
        ChooseRandomDoorInDungeon(startRoom);
        //Dungeon icinden kapi sec
        //Prefab icinden kapi sec
        //Prefab icinden kapiyi ve dungeon icindeki kapinin yonunu karsilastir
        //Prefabin dondurulcegi aciyi bul
        //Prefabin ne kadar otelencegini bul
        //Olusan prefabin boyutu kadar tara. Bossa oraya prefab koy
    }
    private void CreateRoom(GameObject[] room, bool isActive)
    {
        if (!isActive) return;

        for (int i = 0; i < room.Length; i++)
        {
            GameObject tempRoom = Instantiate(room[i], grid.GetNode(startRoomPosition).worldPosition, Quaternion.identity, roomParent);
            rooms.Add(tempRoom);
        }
    }
    private void ChooseRandomDoorInDungeon(GameObject room)
    {
        for (int i = 0; i < room.GetComponent<Room>().doorCount; i++)
        {
            FindDirection(room, i);
        }
    }

    private void FindDirection(GameObject room, int i)
    {
        switch (room.GetComponent<Room>().doors[i].doorDirection)
        {
            case Direction.Front:
            GameObject selectedRoom = ChooseRandomRoomInList();
            int selectedDoorIndex = GetIndexOfRandomDoorInRoom(selectedRoom);
            CompareDoorDirection(room.GetComponent<Room>().doors[i].doorDirection, selectedRoom.GetComponent<Room>().doors[selectedDoorIndex].doorDirection);
                break;
            case Direction.Right:
                break;
            case Direction.Back:
                break;
            case Direction.Left:
                break;
        }
    }
    private void CompareDoorDirection(Direction currentRoomDoorDirection, Direction selectedRoomDoorDirection)
    {
        switch (currentRoomDoorDirection)
        {
            case Direction.Front:
                {
                    switch (selectedRoomDoorDirection)
                    {
                        case Direction.Front:
                            break;
                        case Direction.Right:
                            break;
                        case Direction.Back:
                            break;
                        case Direction.Left:
                            break;
                    }
                    break;
                }
            case Direction.Right:
                {
                    switch (selectedRoomDoorDirection)
                    {
                        case Direction.Front:
                            break;
                        case Direction.Right:
                            break;
                        case Direction.Back:
                            break;
                        case Direction.Left:
                            break;
                    }
                    break;
                }

            case Direction.Back:
                switch (selectedRoomDoorDirection)
                {
                    case Direction.Front:
                        break;
                    case Direction.Right:
                        break;
                    case Direction.Back:
                        break;
                    case Direction.Left:
                        break;
                }
                break;
            case Direction.Left:
                switch (selectedRoomDoorDirection)
                {
                    case Direction.Front:
                        break;
                    case Direction.Right:
                        break;
                    case Direction.Back:
                        break;
                    case Direction.Left:
                        break;
                }
                break;
        }
    }
    
    private void RoomPlacement()
    {
        // Implement room placement logic here
        // Baslangic odami 1. kata koy.
    } */
    #endregion
    #region After
    private void CreateDungeon()
    {
        Vector3 startRoomWorldPos= grid.GetNodeFromGridPos(startRoomPosition).worldPosition;
        GameObject startRoomObject = Instantiate(startRoom, startRoomWorldPos, Quaternion.identity, roomParent) as GameObject;
        RoomNode root = new RoomNode(startRoomWorldPos,null,startRoomObject);

        Room startRoomComp = startRoomObject.GetComponent<Room>();
        GameObject leftCorner = GetLeftCornerOfRoom(startRoomObject, 0);

        Node leftCornerNode = grid.GetNodeFromWorldPos(leftCorner.transform.position);
        if (grid.CheckArea(leftCornerNode, startRoomComp.roomSize, 0))
        {
            grid.DrawArea(leftCornerNode, startRoomComp.roomSize, 0);
        }

        root.roomId = 0;
        roomNodes.Add(root);
        ExpandNode(root);
    }
    private void ExpandNode(RoomNode roomNode)
    {
        if (roomNodes.Count >= maxRoomCount) return;

       
        //Su anki odanin secilen random  kapisi


        //Eski
        int randomIndexOfCurrentRoomDoor = GetIndexOfRandomDoorInRoom(roomNode.room);
        Room currentRoom = roomNode.room.GetComponent<Room>();
        Door currentRoomDoor = currentRoom.doors[randomIndexOfCurrentRoomDoor];

        if (currentRoom.chosenDoorCount >= currentRoom.doorCount)
        {
            //Bu odanin parent odasina git.
            ExpandNode(roomNode.parent);
        }
        else
        {
            //Kapi secilmisse
            if (currentRoomDoor.isChosen)
            {
                //Baska kapi sec. 
                while (currentRoomDoor.isChosen)
                {
                    randomIndexOfCurrentRoomDoor = GetIndexOfRandomDoorInRoom(roomNode.room);
                    currentRoomDoor = currentRoom.doors[randomIndexOfCurrentRoomDoor];
                }
            }
            currentRoomDoor.isChosen = true;//Yer uygunsa sec
            currentRoom.chosenDoorCount++;
        }

        visitedNodes.Add(roomNode);
        roomNode.isVisited = true;

        //Yeni
        Debug.LogWarning(roomNode.room.name);
        GameObject selectedRoomPrefab = ChooseRandomRoomInList();
        if(selectedRoomPrefab == null)
        {
            Debug.LogError("Selected room prefab is null");
            return;
        }
        Room selectedRoom = selectedRoomPrefab.GetComponent<Room>();
        if(selectedRoom == null)
        {
            Debug.LogError("Selected room component is null");
            return;
        }
        int randomIndexOfSelectedRoomDoor = GetIndexOfRandomDoorInRoom(selectedRoomPrefab);
        Door selectedRoomRandomDoor = selectedRoom.doors[randomIndexOfSelectedRoomDoor];
        if(selectedRoomRandomDoor == null)
        {
            Debug.LogError("Selected room prefab is null");
            return;
        }

        int rotationAngle = GetRotationAngle(currentRoomDoor.doorDirection, selectedRoomRandomDoor.doorDirection);
        Vector2 rotatedSize = GetRotatedSize(selectedRoomPrefab, rotationAngle);
        GameObject leftCorner = GetLeftCornerOfRoom(selectedRoomPrefab, rotationAngle);
        if (leftCorner == null)
        {
            Debug.LogError("Left corner is null");
            return;
        }
        Node leftCornerNode = grid.GetNodeFromWorldPos(leftCorner.transform.position);

        if (leftCornerNode == null)
        {
            Debug.LogError("Left corner node is null");
        }
        //Alani tarar true ise oda koyulabilir false ise oda koyulamaz
        if (grid.CheckArea(leftCornerNode, rotatedSize, 0))
        {
            grid.DrawArea(leftCornerNode, rotatedSize, 0);
            Transform currentRoomDoorNodePos = currentRoomDoor.transform.parent.transform;
            Vector3 centerOfRoom = currentRoomDoorNodePos.position + currentRoomDoorNodePos.localPosition;
            selectedRoomRandomDoor.isChosen = true;//Yer uygunsa sec
            selectedRoom.chosenDoorCount++;
            GameObject selectedRoomObject= Instantiate(selectedRoomPrefab, centerOfRoom, Quaternion.Euler(0, rotationAngle, 0), roomParent) as GameObject;
            RoomNode selectedRoomNode = new RoomNode(centerOfRoom,roomNode, selectedRoomObject);
            selectedRoomNode.roomId = roomId++;
            roomNodes.Add(selectedRoomNode);
        }
        //Oda koyulamazsa
        else
        {
            return;
        }

        //Donme acisini bul.
        //Yeni roomun aciya gore sol alt koseyi bul.
        //Odanin sizeini al ve ona gore rotateli halini bul.
        //Odayi tara. 
        //Koyulabiliyor ise merkezi yeni kapinin nodeu arti o nodeun local positionu kadar ekle. 
        //Odayi merkeze koy.
        // Eger koyulamiyorsa 
    }
    private GameObject ChooseRandomRoomInList()
    {
        int randomIndex = Random.Range(0, roomsToBePlaced.Count);
        return roomsToBePlaced[randomIndex];
    }
    private int GetIndexOfRandomDoorInRoom(GameObject room)
    {
        int randomIndex = Random.Range(0, room.GetComponent<Room>().doorCount);
        return randomIndex;
    }
    private int GetRotationAngle(Direction currentRoomDoorDirection, Direction randomRoomDoorDirection)
    {
        if (currentRoomDoorDirection == Direction.None || randomRoomDoorDirection == Direction.None)
        {
            throw new System.Exception("currentRoomDoorDirection or randomRoomDoorDirection is None");
        }
        int currentAngle = 90 * ((int)randomRoomDoorDirection - (int)currentRoomDoorDirection);
        if (currentAngle < 0)
        {
            currentAngle += 360;
        }
        return currentAngle;
    }
    private void RotateObject(float angle, Transform objectToRotate)
    {
        objectToRotate.Rotate(0, angle, 0, Space.Self);
    }
    private GameObject GetLeftCornerOfRoom(GameObject room, int angle)
    {
        if (angle == 0) return room.transform.GetChild(0).transform.GetChild(0).gameObject;
        if (angle == 90) return room.transform.GetChild(0).transform.GetChild(1).gameObject;
        if (angle == 180) return room.transform.GetChild(0).transform.GetChild(2).gameObject;
        if (angle == 270) return room.transform.GetChild(0).transform.GetChild(3).gameObject;
        return null;
    }
    private Vector2 GetRotatedSize(GameObject room, int angle)
    {
        Vector2 roomSize = room.GetComponent<Room>().roomSize;
        if (angle == 90 || angle == 270)
        {
            float temp = roomSize.x;
            roomSize.x = roomSize.y;
            roomSize.y = temp;
        }
        return roomSize;
    }
    #endregion
}
