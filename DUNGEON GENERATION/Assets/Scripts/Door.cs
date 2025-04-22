using UnityEngine;

[System.Serializable]
public class Door
{
    public DoorLocation currentDoorLocation;
    [SerializeField] private Vector3 doorPosition;
    //public Node parentNode;
}
public enum DoorLocation
{
    None,
    Left,
    Right,
    Front,
    Back
}