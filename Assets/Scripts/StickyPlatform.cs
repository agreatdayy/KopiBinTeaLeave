using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prevents player character from sticking to moving platforms' sides
public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
