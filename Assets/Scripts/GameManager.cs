using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] AI ai;
    [SerializeField] List<CellAction> cells;
    public List<CellAction> Cells => cells;
    public bool IsGameOver { get; private set; }
    public int CurrentPlayer { get; private set; }
    private readonly int[][] _gameState = new int[3][];
    private int _winner = -1;
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;
    private void Awake()
    {
        CurrentPlayer = 0;
        //Hide the winner text and play again button
        uiManager.HideWinnerText();
        uiManager.HidePlayAgainButton();
        //Reset the board
        foreach (var cell in cells)
        {
            cell.ResetCell();
        }
        IsGameOver = false;
        PrintBoard();
        //set the score to 0
        uiManager.UpdatePlayerOneScore(_playerOneScore);
        uiManager.UpdatePlayerTwoScore(_playerTwoScore);
    }
    public void EndTurn()
    {
        CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
        CheckForWinner();

        //if the player is an AI, make a move
        if (CurrentPlayer == 1)
        {
            //ai.MakeMove();
            //ai.DefensiveMove();
            ai.OffensiveMove();
        }
        //PrintBoard();
    }
    private void GameOver()
    {
        IsGameOver = true;
        //update the UI for the winner
        uiManager.UpdateWinnerText($"Player {_winner} Wins!");
        uiManager.ShowWinnerText();
        uiManager.ShowPlayAgainButton();
        //Give the winner a point
        if (_winner == 0)
        {
            _playerOneScore++;
            uiManager.UpdatePlayerOneScore(_playerOneScore);
        }
        else
        {
            _playerTwoScore++;
            uiManager.UpdatePlayerTwoScore(_playerTwoScore);
        }
        Debug.Log($"Game Over - Player {_winner} Wins!");
    }

    private void CheckForWinner()
    {
         //Check Rows
         for(var i = 0; i < 3; i++)
         {
             var row = new List<CellAction>();
             for(var j = 0; j < 3; j++)
             {
                 row.Add(cells[i * 3 + j]);
             }

             if (!CheckCells(row)) continue;
             GameOver();
             return;

         }
         //Check Columns
         for (var i  = 0; i < 3; i++)
         {
             var column = new List<CellAction>();
                for (var j = 0; j < 3; j++)
                {
                    column.Add(cells[i + j * 3]);
                }

                if (!CheckCells(column)) continue;
                GameOver();
                return;
         }
         //Check Diagonals
            var diagonal1 = new List<CellAction>(){ cells[0], cells[4], cells[8]};
            var diagonal2 = new List<CellAction>(){ cells[2], cells[4], cells[6]};
            if (CheckCells(diagonal1) || CheckCells(diagonal2))
            {
                GameOver();
                return;
            }
            //Check for a tie
            if (cells.All(cell => cell.CellTypeValue != 0))
            {
                Debug.Log("Tie Game");
                uiManager.UpdateWinnerText("Tie Game");
                uiManager.ShowWinnerText();
                uiManager.ShowPlayAgainButton();
            }
    }
    private bool CheckCells(List<CellAction> cellsToCheck)
    {
        var cellType = cellsToCheck[0].CellTypeValue;
        if (cellType == 0)
            return false;
        if (cellsToCheck.Any(cell => cell.CellTypeValue != cellType))
        {
            return false;
        }

        _winner = cellType;
        return true;
    }
    //print out the current board state
    private void PrintBoard()
    {
        //Populate the GameState array
        for (var i = 0; i < 3; i++)
        {
            _gameState[i] = new int[3];
            for (var j = 0; j < 3; j++)
            {
                _gameState[i][j] = cells[i * 3 + j].CellTypeValue;
            }
        }
        //Print the board
        Debug.Log("Current Board State:");
        for (var i = 0; i < 3; i++)
        {
            Debug.Log($"{_gameState[i][0]} {_gameState[i][1]} {_gameState[i][2]}");
        }
    }
    //Reset the game
    public void ResetGame()
    {
        foreach (var cell in cells)
        {
            cell.ResetCell();
        }
        IsGameOver = false;
        CurrentPlayer = 0;
        _winner = -1;
        uiManager.HideWinnerText();
        uiManager.HidePlayAgainButton();
        
    }
}
