using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int gridSizeX;
    [SerializeField] private int gridSizeY;
    [SerializeField] private int gridSizeZ;

    [SerializeField] private float nodeRadius;
    [SerializeField] private float nodeSpace;
    Node[,,] grid;
    [SerializeField] private GameObject cube;
    [SerializeField] private Vector3 startPos;

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
                    Vector3 worldPos = startPos + new Vector3(x * (nodeRadius + nodeSpace), y * (nodeRadius + nodeSpace), z * (nodeRadius + nodeSpace));
                    grid[x, y, z] = new Node(x, y, z, worldPos, true);
                    Instantiate(cube, grid[x, y, z].worldPosition, Quaternion.identity, transform);
                }
            }
        }
    }
}
