using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core;

public class EnemyScript : MonoBehaviour
{
    private ChessPlayerPlacementHandler chessPiecePosScript;

    private GameObject tileSet;
    
    private void Start()
    {
        chessPiecePosScript = GetComponent<ChessPlayerPlacementHandler>();
        SecureTile();
    }

    public void SecureTile()
    {
        tileSet = ChessBoardPlacementHandler.Instance.GetTile(chessPiecePosScript.row, chessPiecePosScript.column);
        tileSet.GetComponent<TileOccupy>().isVacant = false;
        tileSet.GetComponent<TileOccupy>().isEnemyOccupied = true;
    }
}
