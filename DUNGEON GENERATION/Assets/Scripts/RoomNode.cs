using UnityEngine;

public class RoomNode 
{
    public Vector3 position;
    //public Dictionary<DoorDirection, RoomNode> children = new();
    public RoomNode parent;
    public GameObject room;
    public bool isVisited;
    public int roomId;
    public int level;

    public RoomNode(Vector3 position, RoomNode parent = null, GameObject room = null)
    {
        this.position = position;
        this.parent = parent;
        this.room = room; 
        this.roomId = -1;
        this.level = -1;
        this.isVisited = false;
    }
    public RoomNode(Vector3 position, int level,  RoomNode parent = null, GameObject room = null)
    {
        this.position = position;
        this.level = level;
        this.parent = parent;
        this.room = room; 
        this.roomId = -1;
        this.isVisited = false;
    }
    public void AddChild(RoomNode _child,RoomNode _parent)
    {
        if(_parent == null) return;
        _child.parent = _parent;
    }
}