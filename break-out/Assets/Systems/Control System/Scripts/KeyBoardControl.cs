using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3GameEvent onMovePlayerRequest;
    [SerializeField]
    private GameEvent onStopPlayerRequest;

    void Update()
    {
        //press
        if (Input.GetKey(KeyCode.RightArrow))
            onMovePlayerRequest.Raise(Vector3.right);
        if (Input.GetKey(KeyCode.LeftArrow))
            onMovePlayerRequest.Raise(Vector3.left);

        //release
        if (Input.GetKeyUp(KeyCode.RightArrow))
            onStopPlayerRequest.Raise();
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            onStopPlayerRequest.Raise();
    }
}
