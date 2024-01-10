using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System.Linq;

public class CharaSelect : MonoBehaviour
{
    [Header("対象キャラクター")]
    public GameObject[] PlayableChara;

    public static GameObject Chara;

    //[Header("初期値")]
    int number;


    [Header("Squareシーンで使用")]
    public bool Square;
    [SerializeField] EventSystem eventsystem;
    GameObject selectedObj;
    [SerializeField] GameObject CharaPanel;
    public static GameObject UI;
    [SerializeField] GameObject SubCamera;
    [SerializeField] Button CharaButton;
    [SerializeField] Button MapButton;
    [SerializeField] Button HijackButton;
    public static Button select;
    [SerializeField] Text Triangle0;
    [SerializeField] Text Triangle1;
    [SerializeField] GameObject TextCanvas;
    public string[] CharaName;
    [SerializeField] GameObject[] CharaText;
    [SerializeField] GameObject[] Map;
    public string[] MapName;
    public static int Mapnumber = 0;
    float D_axisH = 0.0f;
    bool right = false, left = false;


    [Header("TimeLineで使用")]
    public bool TimeLine;
    public PlayableDirector director;
    public string TrackName;
    IEnumerable<TrackAsset>tracks;
    TrackAsset track;

    // Start is called before the first frame update
    void Start()
    {
        if (Square)
        {
            UI = CharaPanel;
            select = CharaButton;
            number = PlayerPrefs.GetInt("CharaNumber");
        }

        if (TimeLine)
        {
            // タイムライン内のトラック一覧を取得
            tracks = (director.playableAsset as TimelineAsset).GetOutputTracks();
            // 指定名称のトラックを抜き出す
            track = tracks.FirstOrDefault(x => x.name == TrackName);
            //指定したトラックに任意のオブジェクトをバインド
            director.SetGenericBinding(track, PlayableChara[PlayerPrefs.GetInt("CharaNumber")]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Chara = PlayableChara[PlayerPrefs.GetInt("CharaNumber")];

        if (Square)
        {
            //Dパッド読み込み
            D_axisH = Input.GetAxisRaw("D_Pad_H");

            if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                UI.SetActive(!UI.activeSelf);
                CharaButton.Select();
            }

            if (UI.activeSelf)
            {
                selectedObj = eventsystem.currentSelectedGameObject.gameObject;

                if (selectedObj.name == CharaButton.name)
                {
                    number = D_Pad(number, PlayableChara.Length - 1);

                    CharaSet();
                    TextChange();

                    CharaButton.GetComponentInChildren<Text>().text = CharaName[PlayerPrefs.GetInt("CharaNumber")];

                    Triangle(PlayerPrefs.GetInt("CharaNumber"),PlayableChara.Length - 1);

                    Vector3 CharaPosi = PlayableChara[PlayerPrefs.GetInt("CharaNumber")].transform.position;
                    CapsuleCollider CC = PlayableChara[PlayerPrefs.GetInt("CharaNumber")].GetComponent<CapsuleCollider>();
                    SubCamera.transform.position = new Vector3(CharaPosi.x, CharaPosi.y + CC.height / 1.2f, CharaPosi.z + 1f);
                    Quaternion CharaRota = PlayableChara[PlayerPrefs.GetInt("CharaNumber")].transform.rotation;
                    SubCamera.transform.rotation = Quaternion.Euler(CharaRota.x + 10, CharaRota.y - 180, CharaRota.z);
                }

                else if (selectedObj.name == MapButton.name)
                {
                    Mapnumber = D_Pad(Mapnumber, Map.Length - 1);

                    MapButton.GetComponentInChildren<Text>().text = MapName[Mapnumber];

                    Triangle(Mapnumber, Map.Length - 1);

                    switch (Mapnumber)
                    {
                        case 0:
                            Map[1].SetActive(false);
                            Map[2].SetActive(false);
                            break;
                        case 1:
                            Map[1].SetActive(true);
                            Map[2].SetActive(false);
                            break;
                        case 2:
                            Map[1].SetActive(false);
                            Map[2].SetActive(true);
                            break;
                    }
                }

                else
                {
                    Triangle0.text = "";
                    Triangle1.text = "";
                }

            }
        }
        else
        {
            CharaLoad();
        }
    }


    int D_Pad(int N,int L)
    {
        if (D_axisH > 0.0f && !right && N <L)
        {
            N++;
            right = true;
        }
        if (D_axisH < 0.0f && !left && N > 0)
        {
            N--;
            left = true;
        }
        if (D_axisH == 0.0f)
        {
            right = false;
            left = false;
        }
        return N;
    }


    void Triangle(int N,int L)
    {
        if (selectedObj.name == CharaButton.name)
        {
            Triangle0.transform.position = new Vector3(Triangle0.transform.position.x, CharaButton.transform.position.y, 0);
            Triangle1.transform.position = new Vector3(Triangle1.transform.position.x, CharaButton.transform.position.y, 0);
        }
        else if (selectedObj.name == MapButton.name)
        {
            Triangle0.transform.position = new Vector3(Triangle0.transform.position.x, MapButton.transform.position.y, 0);
            Triangle1.transform.position = new Vector3(Triangle1.transform.position.x, MapButton.transform.position.y, 0);
        }


        if (0 == N)
        {
            Triangle0.text = "";
            Triangle1.text = "△";
        }
        else if (N == L)
        {
            Triangle0.text = "△";
            Triangle1.text = "";
        }
        else
        {
            Triangle0.text = "△";
            Triangle1.text = "△";
        }
    }


    public void CharaSet()
    {
        PlayerPrefs.SetInt("CharaNumber", number);
        PlayerPrefs.Save();
    }

    void CharaLoad()
    {
        for (int i = 0; i < PlayableChara.Length; i++)
        {
            if(i== PlayerPrefs.GetInt("CharaNumber"))
            {
                PlayableChara[i].SetActive(true);
            }
            else
            {
                PlayableChara[i].SetActive(false);
            }
        }
    }

    public void TextLoad()
    {
        TextCanvas.SetActive(!TextCanvas.activeSelf);
        TextChange();
    }

    void TextChange()
    {
        for (int i = 0; i < PlayableChara.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("CharaNumber"))
            {
                CharaText[i].SetActive(true);
            }
            else
            {
                CharaText[i].SetActive(false);
            }
        }
    }

}
