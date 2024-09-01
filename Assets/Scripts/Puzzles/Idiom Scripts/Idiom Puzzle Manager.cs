using System;
using UnityEngine;

public class IdiomPuzzleManager : BasePuzzleManager<IdiomPeiceScript>
{
    // Provide the event implementation specific to IdiomPeiceScript
    protected override event Action<IdiomPeiceScript> OnPuzzlePiecePlaced
    {
        add { IdiomPeiceScript.OnPuzzlePiecePlaced += value; }
        remove { IdiomPeiceScript.OnPuzzlePiecePlaced -= value; }
    }

    protected override event Action<IdiomPeiceScript> OnPuzzlePieceRemoved
    {
        add { IdiomPeiceScript.OnPuzzlePieceRemoved += value; }
        remove { IdiomPeiceScript.OnPuzzlePieceRemoved -= value; }
    }
}
