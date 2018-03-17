using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    public WordSequence[] sequences;
    public int sequenceIndex = 0;
    public int sequenceState;

    Checkerboard checkerPuzzle;
    CrowdControl crowdPuzzle;
    Silhouette silPuzzle;
    public static PuzzleBase[] puzzles;

    void Awake() {
        Instance = this;
    }

    void Start() {

        checkerPuzzle = FindObjectOfType<Checkerboard>();
        if (checkerPuzzle != null) {
            checkerPuzzle.images[0].sprite = sequences[sequenceIndex].checkerImages[0];
            checkerPuzzle.images[1].sprite = sequences[sequenceIndex].checkerImages[1];
        }

        crowdPuzzle = FindObjectOfType<CrowdControl>();
        if (crowdPuzzle != null) {
            crowdPuzzle.wordImages[0].sprite = sequences[sequenceIndex].crowdImages[0];
            crowdPuzzle.wordImages[1].sprite = sequences[sequenceIndex].crowdImages[1];
        }

        silPuzzle = FindObjectOfType<Silhouette>();
        if (silPuzzle != null) {
            silPuzzle.targetRotation = sequences[sequenceIndex].targetRotation;
        }

        puzzles = new PuzzleBase[3];
        puzzles[0] = checkerPuzzle;
        puzzles[1] = crowdPuzzle;
        puzzles[2] = silPuzzle;

        crowdPuzzle.gameObject.SetActive(false);
        silPuzzle.gameObject.SetActive(false);
    }

    public static void UpdateState() {
        puzzles[Instance.sequenceState].gameObject.SetActive(false);

        Instance.sequenceState ++;

        if (Instance.sequenceState >= 3) {
            Debug.Log("ALL PUZZLES COMPLETE");
            return;
        }

        puzzles[Instance.sequenceState].gameObject.SetActive(true);
    }

}

[System.Serializable]
public class WordSequence {
    public string[] words;

    public Sprite[] checkerImages;
    public Sprite[] crowdImages;
    public GameObject mesh;
    public Vector3 targetRotation;
}