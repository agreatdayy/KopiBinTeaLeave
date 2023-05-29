using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoints : MonoBehaviour
{
    [SerializeField] string level;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayfabManager.Instance.SaveLevel(level);
            Debug.Log("Level saved successfully!");
        }
    }
}
