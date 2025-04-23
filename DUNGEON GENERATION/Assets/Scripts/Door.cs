using UnityEngine;

[System.Serializable]
public class Door: MonoBehaviour
{
    public bool isChosen;
    public Direction doorDirection;
    [SerializeField] private Vector3 doorPosition;
    [SerializeField] private Transform doorNodePosition;
    //public Node parentNode;
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