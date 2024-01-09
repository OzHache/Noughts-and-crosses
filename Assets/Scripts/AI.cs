using System.Collections.Generic;
using UnityEngine;


public class AI: MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void MakeMove() // Randomly select a cell and click it
    {
        var cells = _gameManager.Cells;
        //first check that there is at least one empty cell
        var emptyCell = EmptyCell(cells);
        if (!emptyCell)
        {
            Debug.Log("No Empty Cells");
            return;
        }
        var cell = cells[Random.Range(0, cells.Count)];
        while (cell.CellTypeValue != 0)
        {
            cell = cells[Random.Range(0, cells.Count)];
        }
        cell.OnPointerClick(null);
    }

    private static bool EmptyCell(List<CellAction> cells)
    {
        var emptyCell = false;
        foreach (var c in cells)
        {
            if (c.CellTypeValue == 0)
            {
                emptyCell = true;
                break;
            }
        }

        return emptyCell;
    }

    //Algorithm for AI to make a move here : First will be a defensive move, then an offensive move
    //If no move is available, make a random move
    public void DefensiveMove()
    {
        Debug.Log("Defensive Move");
        //Get the current board state
        var board = _gameManager.Cells;
        //first check if there is at least one empty cell
        var emptyCell = EmptyCell(board);
        if (!emptyCell)
        {
            Debug.Log("No Empty Cells");
            return;
        }
        //check if the other player has two in a row
        //check for horizontal win
        for (var i = 0; i < 3; i++)
        {
            //if the first two cells are the other player's and the third is empty, click the third
            if (board[i * 3].CellTypeValue == 1 && board[i * 3 + 1].CellTypeValue == 1 && board[i * 3 + 2].CellTypeValue == 0)
            {
                board[i * 3 + 2].OnPointerClick(null);
                return;
            }
            //if the first and third cells are the other player's and the second is empty, click the second
            if (board[i * 3].CellTypeValue == 1 && board[i * 3 + 1].CellTypeValue == 0 && board[i * 3 + 2].CellTypeValue == 1)
            {
                board[i * 3 + 1].OnPointerClick(null);
                return;
            }
            //if the second and third cells are the other player's and the first is empty, click the first
            if (board[i * 3].CellTypeValue == 0 && board[i * 3 + 1].CellTypeValue == 1 && board[i * 3 + 2].CellTypeValue == 1)
            {
                board[i * 3].OnPointerClick(null);
                return;
            }
        }
        //check for vertical win
        for (var i = 0; i < 3; i++)
        {
            if (board[i].CellTypeValue == 1 && board[i + 3].CellTypeValue == 1 && board[i + 6].CellTypeValue == 0)
            {
                board[i + 6].OnPointerClick(null);
                return;
            }
            if (board[i].CellTypeValue == 1 && board[i + 3].CellTypeValue == 0 && board[i + 6].CellTypeValue == 1)
            {
                board[i + 3].OnPointerClick(null);
                return;
            }
            if (board[i].CellTypeValue == 0 && board[i + 3].CellTypeValue == 1 && board[i + 6].CellTypeValue == 1)
            {
                board[i].OnPointerClick(null);
                return;
            }
        }
        //check for diagonal win
        if (board[0].CellTypeValue == 1 && board[4].CellTypeValue == 1 && board[8].CellTypeValue == 0)
        {
            board[8].OnPointerClick(null);
            return;
        }
        if (board[0].CellTypeValue == 1 && board[4].CellTypeValue == 0 && board[8].CellTypeValue == 1)
        {
            board[4].OnPointerClick(null);
            return;
        }
        if (board[0].CellTypeValue == 0 && board[4].CellTypeValue == 1 && board[8].CellTypeValue == 1)
        {
            board[0].OnPointerClick(null);
            return;
        }
        if (board[2].CellTypeValue == 1 && board[4].CellTypeValue == 1 && board[6].CellTypeValue == 0)
        {
            board[6].OnPointerClick(null);
            return;
        }
        if (board[2].CellTypeValue == 1 && board[4].CellTypeValue == 0 && board[6].CellTypeValue == 1)
        {
            board[4].OnPointerClick(null);
            return;
        }
        if (board[2].CellTypeValue == 0 && board[4].CellTypeValue == 1 && board[6].CellTypeValue == 1)
        {
            board[2].OnPointerClick(null);
            return;
        }
        //no defensive move available, make an random move
        Debug.Log("No Defensive Move");
        MakeMove();
    }
    
    //Second will be an offensive move Where it will check to see if it has two in a row and then make a move to win
    public void OffensiveMove()
    {
        Debug.Log("Offensive Move");
        //Get the current board state
        var board = _gameManager.Cells;
        //first check if there is at least one empty cell
        var emptyCell = EmptyCell(board);
        if (!emptyCell)
        {
            Debug.Log("No Empty Cells");
            return;
        }
        //Horizontal win
        for (var i = 0; i < 3; i++)
        {
            //if the first two cells are the this player's and the third is empty, click the third
            if (board[i * 3].CellTypeValue == 2 && board[i * 3 + 1].CellTypeValue == 2 && board[i * 3 + 2].CellTypeValue == 0)
            {
                board[i * 3 + 2].OnPointerClick(null);
                return;
            } else if (board[i * 3].CellTypeValue == 2 && board[i * 3 + 1].CellTypeValue == 0 && board[i * 3 + 2].CellTypeValue == 2)
            {
                board[i * 3 + 1].OnPointerClick(null);
                return;
            } else if (board[i * 3].CellTypeValue == 0 && board[i * 3 + 1].CellTypeValue == 2 && board[i * 3 + 2].CellTypeValue == 2)
            {
                board[i * 3].OnPointerClick(null);
                return;
            }
        }
        //Vertical win
        for (var i = 0; i < 3; i++)
        {
            if (board[i].CellTypeValue == 2 && board[i + 3].CellTypeValue == 2 && board[i + 6].CellTypeValue == 0)
            {
                board[i + 6].OnPointerClick(null);
                return;
            } else if (board[i].CellTypeValue == 2 && board[i + 3].CellTypeValue == 0 && board[i + 6].CellTypeValue == 2)
            {
                board[i + 3].OnPointerClick(null);
                return;
            } else if (board[i].CellTypeValue == 0 && board[i + 3].CellTypeValue == 2 && board[i + 6].CellTypeValue == 2)
            {
                board[i].OnPointerClick(null);
                return;
            }
        }
        //Diagonal win
        if (board[0].CellTypeValue == 2 && board[4].CellTypeValue == 2 && board[8].CellTypeValue == 0)
        {
            board[8].OnPointerClick(null);
            return;
        } else if (board[0].CellTypeValue == 2 && board[4].CellTypeValue == 0 && board[8].CellTypeValue == 2)
        {
            board[4].OnPointerClick(null);
            return;
        } else if (board[0].CellTypeValue == 0 && board[4].CellTypeValue == 2 && board[8].CellTypeValue == 2)
        {
            board[0].OnPointerClick(null);
            return;
        } else if (board[2].CellTypeValue == 2 && board[4].CellTypeValue == 2 && board[6].CellTypeValue == 0)
        {
            board[6].OnPointerClick(null);
            return;
        } else if (board[2].CellTypeValue == 2 && board[4].CellTypeValue == 0 && board[6].CellTypeValue == 2)
        {
            board[4].OnPointerClick(null);
            return;
        } else if (board[2].CellTypeValue == 0 && board[4].CellTypeValue == 2 && board[6].CellTypeValue == 2)
        {
            board[2].OnPointerClick(null);
            return;
        }
        //no offensive move available, make an random move
        Debug.Log("No Offensive Move");
        MakeMove();
    }
}
