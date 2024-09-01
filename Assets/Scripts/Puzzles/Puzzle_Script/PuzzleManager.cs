using System;
using UnityEngine;

public class PuzzleManager : BasePuzzleManager<PuzzlePiece>
{
    // Provide the event implementation specific to PuzzlePiece
    protected override event Action<PuzzlePiece> OnPuzzlePiecePlaced
    {
        add { PuzzlePiece.OnPuzzlePiecePlaced += value; }
        remove { PuzzlePiece.OnPuzzlePiecePlaced -= value; }
    }

    protected override event Action<PuzzlePiece> OnPuzzlePieceRemoved
    {
        add { PuzzlePiece.OnPuzzlePieceRemoved += value; }
        remove { PuzzlePiece.OnPuzzlePieceRemoved -= value; }
    }
}
