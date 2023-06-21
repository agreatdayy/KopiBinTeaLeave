using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User UserInstance;
    string userId;
    int levels;
    public int currentLevel;

    // Start is called before the first frame update
    void Awake() {
        UserInstance = this;
        userId = PlayfabManager.Instance.currentPlayer;
        currentLevel = 1;
    }

    void GetUserLevels() {
        PlayfabManager.Instance.GetLevels();
        if (!int.TryParse(PlayfabManager.Instance.numberOfLevels, out levels)) {
            return;
        }
    }

    public int ReturnUserLevels() {
        GetUserLevels();
        return this.levels;
    }


}
