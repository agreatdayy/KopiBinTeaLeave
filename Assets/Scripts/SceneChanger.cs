using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] float changeTime;
    [SerializeField] int sceneNumber;

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        
        if (changeTime <= 0) 
        {
        SceneManager.LoadScene(sceneNumber);
        }
    }
}
