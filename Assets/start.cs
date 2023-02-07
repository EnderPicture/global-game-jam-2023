using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Animation
            // Invoke("ladScene", 1f);
            loadScene();
        }
    }

    void loadScene() {
        SceneManager.LoadScene("MAIN", LoadSceneMode.Single);
    }
}
