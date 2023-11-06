using UnityEngine;

public class Node : MonoBehaviour
{ 
    public Block OccupiedBlock { get; set; }
    public Vector2 Pos => transform.position;
}
