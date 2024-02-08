using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int cols = 0;
    public int rows = 0;
    public float squareOffset = 0.0f;
    //grid square prefab
    public GameObject gridSquare;
    public Vector2 startPos = new Vector2(0.0f, 0.0f);
    //scale of grid square
    public float squareScale = 1.0f;

    private List<GameObject> gridSquares = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
