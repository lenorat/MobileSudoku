using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int cols = 0;
    public int rows = 0;
    public float squareOffset = 0.0f;
    //grid square prefab
    public GameObject GridSquare;
    public Vector2 startPos = new Vector2(0.0f, 0.0f);
    //scale of grid square
    public float squareScale = 1.0f;

    private List<GameObject> gridSquares = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (GridSquare.GetComponent<GridSquare>() == null)
        {
            Debug.LogError("This game object is missing a GridSquare script!");
        }

        CreateGrid();
        SetGridNums();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method creates the sudoku grid depending on level chosen.
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePos();
    }

    //This method spawns the grid squares depending on level chosen.
    private void SpawnGridSquares()
    {
        //starting from index 0 - 6 each row,
        //0-6 = row 1, 7-13 = row 2 ....
        //traverse the number of columns and rows to spawn grid squares.
        for(int row = 0; row < rows; row++) { 
            for(int col = 0; col< cols; col++)
            {
                gridSquares.Add(Instantiate(GridSquare) as GameObject);
                //make grid square child of game object holding this script
                gridSquares[gridSquares.Count - 1].transform.parent = this.transform;
                //the last object should have a square scale
                gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
            }
        }

    }

    //This method takes care of the position of the square as a UI element.
    private void SetSquarePos()
    {
        var squareRect = gridSquares[0].GetComponent<RectTransform>();
        //Gap between squares
        Vector2 offset = new Vector2();
        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + squareOffset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + squareOffset;

        int col_num = 0;
        int row_num = 0;

        //spawn square one by one
        foreach(GameObject square in gridSquares)
        {
            //if we exceed column numbers, we want to switch to the next row
            if (col_num + 1 > cols)
            {
                //proceed to next row
                row_num++;
                //reset column number (for new row to fill)
                col_num = 0;
            }

            var x_offset = offset.x * col_num;
            var y_offset = offset.y * row_num;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPos.x + x_offset, startPos.y - y_offset);
            //increment column number
            col_num++;
        }
    }

    //This method sets the grid numbers in the square (range of 0-9)
    private void SetGridNums()
    {
        foreach(var square in gridSquares)
        {
            square.GetComponent<GridSquare>().SetNumber(Random.Range(0,10));
        }
    }
}
