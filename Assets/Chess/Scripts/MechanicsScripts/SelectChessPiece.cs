using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core;

public class SelectChessPiece : MonoBehaviour
{
    private ChessPlayerPlacementHandler chessPiecePosScript;

    private GameObject tileSet;
    private GameObject tempTile;

    private void Start()
    {
        chessPiecePosScript = GetComponent<ChessPlayerPlacementHandler>();
        SecureTile();
    }

    public void SecureTile()
    {
        tileSet = ChessBoardPlacementHandler.Instance.GetTile(chessPiecePosScript.row, chessPiecePosScript.column);
        tileSet.GetComponent<TileOccupy>().isVacant = false;
    }

    void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights(); 

        switch(gameObject.name)
        {
            case "Pawn":
                PawnMovement();
                break;
            
            case "Rook":
                RookMovement();
                break;

            case "Bishop":
                BishopMovement();
                break; 

            case "Knight":
                KnightMovement();
                break;
            
            case "Queen":
                QueenMovement();
                break;

            case "King":
                KingMovement();
                break;
        }
    }

    //Pawn Movement Function
    private void PawnMovement()
    {
        for(int i = chessPiecePosScript.row + 1; i <= chessPiecePosScript.row + 2; i++)         // Highlights paths
        {
            if(CheckVacancy(i,chessPiecePosScript.column))
                ChessBoardPlacementHandler.Instance.Highlight(i, chessPiecePosScript.column);
            else
            {
                if(CheckEnemyOccupation(i,chessPiecePosScript.column))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(i, chessPiecePosScript.column);
                }
                break;
            }
        }
    }

    //Rook Movement Function
    private void RookMovement()
    {
        for(int i = chessPiecePosScript.row + 1; i <= 7; i++)           // Highlights vertical path
        {
            if(CheckVacancy(i, chessPiecePosScript.column))
                ChessBoardPlacementHandler.Instance.Highlight(i, chessPiecePosScript.column);
            else
            {
                if(CheckEnemyOccupation(i, chessPiecePosScript.column))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(i, chessPiecePosScript.column);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.row - 1; i >= 0; i--)           // Highlights vertical path
        {
            if(CheckVacancy(i, chessPiecePosScript.column))
                ChessBoardPlacementHandler.Instance.Highlight(i, chessPiecePosScript.column);
            else
            {
                if(CheckEnemyOccupation(i, chessPiecePosScript.column))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(i, chessPiecePosScript.column);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.column + 1; i <= 7; i++)           // Highlights Horizontal path
        {
            if(CheckVacancy(chessPiecePosScript.row, i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row, i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row, i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row, i);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.column - 1; i >= 0; i--)           // Highlights horizontal path
        {
            if(CheckVacancy(chessPiecePosScript.row, i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row, i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row, i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row, i);
                }
                break;
            }
        }
    }

    //Bishop Movement Function
    private void BishopMovement()
    {   
        // Top right side diagonal
        for(int i = 1; chessPiecePosScript.row + i < 8 && chessPiecePosScript.column + i < 8; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row + i, chessPiecePosScript.column + i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row + i, chessPiecePosScript.column + i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row + i, chessPiecePosScript.column + i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row + i, chessPiecePosScript.column + i);
                }
                break;
            }
        }

        //bottom right side diagonal
        for(int i = 1; chessPiecePosScript.row - i >= 0 && chessPiecePosScript.column + i < 8; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row - i, chessPiecePosScript.column + i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row - i, chessPiecePosScript.column + i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row - i, chessPiecePosScript.column + i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row - i, chessPiecePosScript.column + i);
                }
                break;
            }
        }

        // Top left side diagonal
        for(int i = 1; chessPiecePosScript.row + i < 8  && chessPiecePosScript.column - i >= 0; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row + i, chessPiecePosScript.column - i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row + i, chessPiecePosScript.column - i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row + i, chessPiecePosScript.column - i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row + i, chessPiecePosScript.column - i);
                }
                break;
            }
        }

        // Bottom left side diagonal
        for(int i = 1; chessPiecePosScript.row - i >= 0  && chessPiecePosScript.column - i >= 0; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row - i, chessPiecePosScript.column - i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row - i, chessPiecePosScript.column - i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row - i, chessPiecePosScript.column - i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row - i, chessPiecePosScript.column - i);
                }
                break;
            }
        }
    }

    //Knight Movement Function
    private void KnightMovement()
    {
        int[] rowOffsets = { -2, -1, 1, 2, 2, 1, -1, -2 };      // -2 and 1 make the combination of moving 2 square down and 1 in right sqaure
        int[] columnOffsets = { 1, 2, 2, 1, -1, -2, -2, -1 };   // making L-shape movement using these combinations

        for (int i = 0; i <= 7; i++)                                // for loop used here to extract all the moves & not highlight every paths
        {
            int newRow = chessPiecePosScript.row + rowOffsets[i];
            int newColumn = chessPiecePosScript.column + columnOffsets[i];

            if (IsPositionValid(newRow, newColumn))
            {
                if(CheckVacancy(newRow, newColumn))
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newColumn);           //highlights the tile where knight can move
                else
                {
                    if(CheckEnemyOccupation(newRow, newColumn))
                    {
                        ChessBoardPlacementHandler.Instance.EnemyHighlight(newRow, newColumn);
                    }
                }

            }
        }
    }

    //Queen Movement Function
    private void QueenMovement()
    {
        FindAllDiagonalMoves();     //extract all the diagonal moves

        FindAllStraightMoves();     //extract all the horizontal and vertical moves

    }

    private void FindAllDiagonalMoves()
    {
        // Top right side diagonal
        for(int i = 1; chessPiecePosScript.row + i < 8 && chessPiecePosScript.column + i < 8; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row + i, chessPiecePosScript.column + i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row + i, chessPiecePosScript.column + i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row + i, chessPiecePosScript.column + i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row + i, chessPiecePosScript.column + i);
                }
                break;
            }
        }

        //bottom right side diagonal
        for(int i = 1; chessPiecePosScript.row - i >= 0 && chessPiecePosScript.column + i < 8; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row - i, chessPiecePosScript.column + i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row - i, chessPiecePosScript.column + i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row - i, chessPiecePosScript.column + i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row - i, chessPiecePosScript.column + i);
                }
                break;
            }
        }

        // Top left side diagonal
        for(int i = 1; chessPiecePosScript.row + i < 8  && chessPiecePosScript.column - i >= 0; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row + i, chessPiecePosScript.column - i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row + i, chessPiecePosScript.column - i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row + i, chessPiecePosScript.column - i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row + i, chessPiecePosScript.column - i);
                }
                break;
            }
        }

        // Bottom left side diagonal
        for(int i = 1; chessPiecePosScript.row - i >= 0  && chessPiecePosScript.column - i >= 0; i++)
        {
            if(CheckVacancy(chessPiecePosScript.row - i, chessPiecePosScript.column - i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row - i, chessPiecePosScript.column - i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row - i, chessPiecePosScript.column - i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row - i, chessPiecePosScript.column - i);
                }
                break;
            }
        }
    }

    private void FindAllStraightMoves()
    {
        for(int i = chessPiecePosScript.row + 1; i <= 7; i++)           // Highlights vertical path
        {
            if(CheckVacancy(i, chessPiecePosScript.column))
                ChessBoardPlacementHandler.Instance.Highlight(i, chessPiecePosScript.column);
            else
            {
                if(CheckEnemyOccupation(i, chessPiecePosScript.column))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(i, chessPiecePosScript.column);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.row - 1; i >= 0; i--)           // Highlights vertical path
        {
            if(CheckVacancy(i, chessPiecePosScript.column))
                ChessBoardPlacementHandler.Instance.Highlight(i, chessPiecePosScript.column);
            else
            {
                if(CheckEnemyOccupation(i, chessPiecePosScript.column))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(i, chessPiecePosScript.column);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.column + 1; i <= 7; i++)           // Highlights Horizontal path
        {
            if(CheckVacancy(chessPiecePosScript.row, i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row, i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row, i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row, i);
                }
                break;
            }
        }

        for(int i = chessPiecePosScript.column - 1; i >= 0; i--)           // Highlights horixontal path
        {
            if(CheckVacancy(chessPiecePosScript.row, i))
                ChessBoardPlacementHandler.Instance.Highlight(chessPiecePosScript.row, i);
            else
            {
                if(CheckEnemyOccupation(chessPiecePosScript.row, i))
                {
                    ChessBoardPlacementHandler.Instance.EnemyHighlight(chessPiecePosScript.row, i);
                }
                break;
            }
        }
    }

    //King movement function
    private void KingMovement()
    {
        int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };       // combination of 1 square down then 1 sqaure left like this
        int[] columnOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };    //  iterating through combination, on current position of king to get all moves

        for (int i = 0; i <= 7; i++)
        {
            int newRow = chessPiecePosScript.row + rowOffsets[i];
            int newColumn = chessPiecePosScript.column + columnOffsets[i];

            if (IsPositionValid(newRow, newColumn))
            {
                if(CheckVacancy(newRow, newColumn))
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newColumn);
                else
                {
                    if(CheckEnemyOccupation(newRow, newColumn))
                    {
                        ChessBoardPlacementHandler.Instance.EnemyHighlight(newRow, newColumn);
                    }
                }
            }
        }
    }

    //function to check if a row or column is inside the board or not
    private bool IsPositionValid(int row, int column) 
    {
        if (row < 0 || row >= 8 || column < 0 || column >= 8)
            return false;
        else
            return true;
        
    }

    // Function used for checking if a tile is vacant or not
    private bool CheckVacancy(int row, int column)
    {
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
        return (tempTile.GetComponent<TileOccupy>().isVacant);
    }

    // Function used for checking if a tile is occupied by enemy or not
    private bool CheckEnemyOccupation(int row, int column)
    {
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
        return (tempTile.GetComponent<TileOccupy>().isEnemyOccupied);
    }
}
