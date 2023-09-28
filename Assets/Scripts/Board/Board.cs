
using UnityEngine;

public class Board : MonoBehaviour
{
    [field: SerializeField] public Transform[] Roads { get; private set; }
    public Vector3 Scale => Roads[0].localScale;
    public Vector3 Position => transform.position;
    
}