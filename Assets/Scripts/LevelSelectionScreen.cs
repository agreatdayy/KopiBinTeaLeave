using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour
{
    static int levels;

    public Text message;

    // Continuously updates user's progress
    void Update()
    {   
        levels = User.UserInstance.ReturnUserLevels();
    }

    // Loads tutorial level
    public void TutorialLevel() {
        SceneManager.LoadScene(2);
    }

    // Loads level 1-1
    public void LevelOneOne() {
        SceneManager.LoadScene(8);
    }

    // Loads level 1-2, if unlocked
    public void LevelOneTwo() {
        // Checks if user has unlocked level
        if (levels >= 2) {
            // Loads the level
            SceneManager.LoadScene(9);
        } else {
            // Informs user that they have not unlocked the level
            message.text = "Level not yet unlocked!";
        }
    }

    // Loads level 2-1, if unlocked
    public void LevelTwoOne() {
        // Checks if user has unlocked level
        if (levels >= 3) {
            // Loads the level
            SceneManager.LoadScene(11);
        } else {
            // Informs user that they have not unlocked the level
            message.text = "Level not yet unlocked!";
        }
    }

    // Loads level 2-2, if unlocked
    public void LevelTwoTwo() {
        // Checks if user has unlocked level
        if (levels >= 4) {
            // Loads the level
            SceneManager.LoadScene(12);
        } else {
            // Informs user that they have not unlocked the level
            message.text = "Level not yet unlocked!";
        }
    }

    // Loads level 3, if unlocked
    public void LevelThree() {
        // Checks if user has unlocked level
        if (levels >= 5) {
            // Loads the level
            SceneManager.LoadScene(15);
        } else {
            // Informs user that they have not unlocked the level
            message.text = "Level not yet unlocked!";
        }
    }

    // Takes user back to main menu
    public void Logout() {
        SceneManager.LoadScene(0);
    }

}
