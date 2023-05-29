using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour
{
    static int levels;

    public Text message;
    // Start is called before the first frame update
    void Start()
    {   
        levels = User.UserInstance.ReturnUserLevels();
    }


    public void LevelOneOne() {
        SceneManager.LoadScene(2);
    }

    public void LevelOneTwo() {
        if (levels >= 2) {
            SceneManager.LoadScene(3);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelOneThree() {
        if (levels >= 3) {
            SceneManager.LoadScene(4);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoOne() {
        if (levels >= 4) {
            SceneManager.LoadScene(5);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoTwo() {
        if (levels >= 5) {
            SceneManager.LoadScene(6);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelTwoThree() {
        if (levels >= 6) {
            SceneManager.LoadScene(7);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelThreeOne() {
        if (levels >= 7) {
            SceneManager.LoadScene(8);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelThreeTwo() {
        if (levels >= 8) {
            SceneManager.LoadScene(9);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }

    public void LevelThreeThree() {
        if (levels >= 9) {
            SceneManager.LoadScene(10);
        } else {
            message.text = "Level not yet unlocked!";
        }
    }
}
