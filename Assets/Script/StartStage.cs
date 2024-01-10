using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartStage : MonoBehaviour
{
    //public static string StageName;
    Button cube;
    Button sphere;
    Button cylinder;
    [SerializeField] private GameObject TaitolUI;
    [SerializeField] private GameObject SelectUI;
    [SerializeField] private string StageName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadStage()
    {
        SceneManager.LoadScene(StageName);
        PlayerController2.two = false;
        QTETimer.TimeOver = false; 
        GameManager.ready = true;
    }

    public void Modoru()
    {
        SelectUI.SetActive(!SelectUI.activeSelf);
        TaitolUI.SetActive(!TaitolUI.activeSelf);
        Taitol();
    }

    public void Taitol()
    {
        cube = GameObject.Find("/Canvas/Title_Panel/Button1").GetComponent<Button>();
        sphere = GameObject.Find("/Canvas/Title_Panel/Button2").GetComponent<Button>();
        cylinder = GameObject.Find("/Canvas/Title_Panel/Button3").GetComponent<Button>();
        cube.Select();
    }
}
