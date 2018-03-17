using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour {

    protected virtual bool CanSolve() { return false; }

    protected void UpdateGameManager() {
        GameManager.UpdateState();
    }
}
