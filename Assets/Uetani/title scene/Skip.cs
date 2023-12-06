using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Skip : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "start" && Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(StartStage.StageName);
        }else if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
