using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User UserInstance;
    string userId;
    int levels;

    void Awake() {
        // Sets user instance for current game session
        UserInstance = this;
        userId = PlayfabManager.Instance.currentPlayer;
    }

    // Gets user's saved progress to use for current game session
    void GetUserLevels() {
        PlayfabManager.Instance.GetLevels();
        if (!int.TryParse(PlayfabManager.Instance.numberOfLevels, out levels)) {
            Debug.Log(this.levels);
            return;
        }
        
    }

    // Returns user's saved progress for use in current game session
    public int ReturnUserLevels() {
        GetUserLevels();
        return this.levels;
    }


}
