using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using JetBrains.Annotations;
public class RoomNode 
{
    public Vector3 position;
    //public Dictionary<DoorDirection, RoomNode> children = new();
    public RoomNode parent;
    public GameObject room;
    public bool isVisited;
    public int roomId;
    public int level;

    public RoomNode(Vector3 position, int level,  RoomNode parent = null)
    {
        this.position = position;
        this.level = level;
        this.parent = parent;
    }
    public void AddChild(RoomNode _child,RoomNode _parent)
    {
        if(_parent == null) return;
        _child.parent = _parent;
    }
}