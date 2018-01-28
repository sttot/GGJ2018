using System.Collections;
using UnityEngine;

public class Node {

    public bool         bWalkable;
    public Vector3      v3WorldPosition;

    public Node(bool _bWalkable, Vector3 _v3WorldPos)
    {
        bWalkable       = _bWalkable;
        v3WorldPosition = _v3WorldPos;
    }
}
