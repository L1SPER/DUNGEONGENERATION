using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int gridSizeX;
    [SerializeField] private int gridSizeY;
    [SerializeField] private int gridSizeZ;

    [SerializeField] private float nodeXRadius;
    [SerializeField] private float nodeYRadius;
    [SerializeField] private float nodeZRadius;


    [SerializeField] private float nodeXSpace;
    [SerializeField] private float nodeYSpace;
    [SerializeField] private float nodeZSpace;

    Node[,,] grid;
    [SerializeField] private GameObject cube;
    [SerializeField] private Vector3 startPos;

    [SerializeField] private LayerMask walkableLayerMask;

    void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY, gridSizeZ];
        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 worldPos = startPos + new Vector3(x * (nodeXRadius + nodeXSpace), y * (nodeYRadius + nodeYSpace), z * (nodeZRadius + nodeZSpace));
                    grid[x, y, z] = new Node(x, y, z, worldPos, true);
                    Instantiate(cube, grid[x, y, z].worldPosition, Quaternion.identity, transform);
                }
            }
        }
    }
    public Node GetNode(int x, int y, int z)
    {
        if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY || z < 0 || z >= gridSizeZ)
        {
            return null;
        }
        return grid[x, y, z];
    }
    public Node GetNode(Vector3 gridPos)
    {
        if (gridPos.x < 0 || gridPos.x >= gridSizeX || gridPos.y < 0 || gridPos.y >= gridSizeY || gridPos.z < 0 || gridPos.z >= gridSizeZ)
        {
            return null;
        }
        return grid[(int)gridPos.x,(int)gridPos.y,(int)gridPos.z];
    }

}
