using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoints : MonoBehaviour
{
    [SerializeField] string level;
    [SerializeField] int nextScene;

    // Used by level checkpoints for saving user level and loading next scene.
    public void OnTriggerEnter2D(Collider2D other) {
        // Check if player has entered checkpoint
        if (other.tag == "Player") {
            // Sets the next scene to load
            PlayfabManager.Instance.nextScene = this.nextScene;
            // Saves user's progress
            PlayfabManager.Instance.SaveLevel(level);
            Debug.Log("Level saved successfully!");
        }
    }
}
