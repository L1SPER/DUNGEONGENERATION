using System.Collections.Generic;
using TreeEditor;
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

    [SerializeField] private int maxRoomCount=30;
    private List<RoomNode> roomNodes = new();
    private HashSet<RoomNode> visitedNodes = new HashSet<RoomNode>();
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

        CreateRoom(startRoom, isStartRoomActive);
        CreateRoom(room1x1Prefabs, is1x1RoomGenerated);
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
    private void CreateRoom(GameObject room, bool isActive)
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
    //  OTELEME
    private void CalculateNewPositionOfRoom()
    {

    }
    private void MoveObject()
    {

    }
    private void RotateObject()
    {

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
    private void RoomPlacement()
    {
        // Implement room placement logic here
        // Baslangic odami 1. kata koy.
    }
    #endregion
    #region After
    private void CreateDungeon()
    {
        RoomNode root= new RoomNode(startRoomPosition,0);
        root.room = startRoom;
        root.roomId = 0;
        roomNodes.Add(root);
        ExpandNode(root);
    }
    private void ExpandNode(RoomNode roomNode)
    {
        if(roomNodes.Count>=maxRoomCount) return;

        visitedNodes.Add(roomNode);

        //Su anki odanin secilen random  kapisi

        
        //Eski
        Door currentRoomDoor= roomNode.room.GetComponent<Room>().doors[GetIndexOfRandomDoorInRoom(roomNode.room)];
        currentRoomDoor.isChosen=true;

        //Yeni
        GameObject randomRoom= ChooseRandomRoomInList();
        Door randomDoor= randomRoom.GetComponent<Room>().doors[GetIndexOfRandomDoorInRoom(randomRoom)];
        randomDoor.isChosen=true;


        


        
        //Random oda sec
        //Random kapi sec
        //Eslesen  kapilari yonlerini karsilastir
        //Dondurme acisini bul
        //Buna gore otele
        // Yeni kapinin nodeunun koordinatini bul
        // Eski kapinin nodeuna ileriyse z+1, geri ise z-1 vs. ekleyerek yeni kapinin nodeu degerini  bul.

        //Yeni  kapinin nodeunun merkeze olan uzakligini bul
        //Bu uzakligi tersine otele(Rotate  olunca oteleme degerleri degisiyor)
        //Yeni odanin merkezini  o buldugun degere  koy.


    }
    #endregion
}
