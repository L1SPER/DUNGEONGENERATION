using UnityEngine;
public static class DirectionHelper
{
    public static Vector3 GetOffset(Direction dir)
    {
        return dir switch
        {
            Direction.Left => new Vector3(-1, 0, 0),
            Direction.Right => new Vector3(1, 0, 0),
            Direction.Front => new Vector3(0, 0, 1),
            Direction.Back => new Vector3(0, 0, -1),
            Direction.Up => new Vector3(0, 1, 0),
            Direction.Down => new Vector3(0, -1, 0),
            _ => Vector3.zero
        };
    }
    public static Direction GetOpposite(Direction dir)
    {
        return dir switch
        {
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Front => Direction.Back,
            Direction.Back => Direction.Front,
            _ => Direction.None
        };
    }
}