using UnityEngine;

public class Node
{
    public int gridX;
    public int gridY;
    public int gridZ;
    public Vector3 gridPos;
    public Vector3 worldPosition;
    public GameObject gameObject;
    public bool walkable;

    public Node(int gridX, int gridY,int gridZ)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.gridZ = gridZ;
        this.gridPos = new Vector3(gridX, gridY, gridZ);
    }
    public Node(int gridX, int gridY,int gridZ, Vector3 worldPosition)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.gridZ = gridZ;
        this.gridPos = new Vector3(gridX, gridY, gridZ);
        this.worldPosition = worldPosition;
    }
    public Node(int gridX, int gridY,int gridZ, Vector3 worldPosition, bool walkable)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.gridZ = gridZ;
        this.gridPos = new Vector3(gridX, gridY, gridZ);
        this.worldPosition = worldPosition;
        this.walkable = walkable;
    }
}
