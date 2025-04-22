using UnityEngine;

class Room : MonoBehaviour
{
    [SerializeField] private Vector2 roomSize;
    [SerializeField] private int doorCount;
    [SerializeField] private Door[] doors;
}