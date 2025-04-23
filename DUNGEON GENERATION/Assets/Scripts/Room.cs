using UnityEngine;

class Room : MonoBehaviour
{
    [SerializeField] public Vector2 roomSize;
    [SerializeField] public int doorCount;
    [SerializeField] public Door[] doors;
}