using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoints : MonoBehaviour
{
    [SerializeField] string level;
    //BoxCollider2D myBoxCollider;

    //void Start() {
    //    myBoxCollider = GetComponent<BoxCollider2D>();
    //}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
        //if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player"))) { 
            PlayfabManager.Instance.SaveLevel(level);
            Debug.Log("Level saved successfully!");
        }
    }
}
