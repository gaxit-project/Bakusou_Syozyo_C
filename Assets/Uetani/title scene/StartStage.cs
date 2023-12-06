using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartStage : MonoBehaviour
{
    public static string StageName;
    Button cube;
    Button sphere;
    Button cylinder;
    [SerializeField] private GameObject TaitolUI;
    [SerializeField] private GameObject SelectUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load1()
    {
        SceneManager.LoadScene("start");
        StageName = "stage1";
        PlayerController2.two = false;
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

    }
    public void Load2()
    {
        SceneManager.LoadScene("start");
        StageName = "stage2";
        PlayerController2.two = false;
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

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
