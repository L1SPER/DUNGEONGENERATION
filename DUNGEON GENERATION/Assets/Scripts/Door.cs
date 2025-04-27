using UnityEngine;

[System.Serializable]
public class Door: MonoBehaviour
{
    public bool isChosen;
    public Direction doorDirection;
    //[SerializeField] public Vector3 doorPosition;
}
public enum Direction
{
    None,
    Front,
    Right,
    Back,
    Left,
    Up,
    Down
}