using Skripsi.Ship.MovementContoller;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private GameState _gameState;
    private QuestState _questState;
    public GameObject ArrowDirection;
    public TMP_Text QuestText;


    private void Awake()
    {
        if(PlayerPrefs.GetInt("QuestGame") == 0)
        {
            SetFirstGame();
            PlayerPrefs.SetInt("QuestGame", 1);
        }

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        switch (PlayerPrefs.GetInt("QuestGame"))
        {
            case 0:
                SetFirstGame();
                break;
            case 1:
                _questState = QuestState.QSIntro;
                break;
            case 2:
                _questState = QuestState.QSDBencanaAlamBanjir;
                break;
            case 3:
                _questState = QuestState.QSDBencanaAlamTanahLongsor;
                break;

            default:
                PlayerPrefs.SetInt("QuestGame", 0);
                break;
        }
    }

    [System.Obsolete]
    private void LateUpdate()
    {
        if(ArrowDirection.active)
        {
            ArrowDirection.transform.position = GameObject.Find("Main Character").transform.position;
        }
    }

    [System.Obsolete]
    private void Update()
    {

        GetSetInputPlayer();

        // GAME STATE
        switch (_gameState)
        {
            case GameState.Playing:
                break;
            case GameState.QuestDone:
                ArrowDirection.SetActive(false);
                QuestText.gameObject.SetActive(false);
                break;
            case GameState.Paused:
                break;
        }

        // QUEST STATE
        switch (_questState)
        {
            case QuestState.QSIntro:
                SetFirstGame();
                break;
            case QuestState.QSDBencanaAlamBanjir:
                break;
            case QuestState.QSDBencanaAlamTanahLongsor:
                break;
            case QuestState.QSDBencanaKebakaranHutan:
                break;
            case QuestState.QSSimulasiBencanaAlamBanjir:
                break;
            case QuestState.QSSimulasiBencanaAlamTanahLongsor:
                break;
            case QuestState.QSSimulasiBencanaKebakaranHutan:
                break;
            case QuestState.QSGoodEndings:
                break;
            case QuestState.QSBadEndings:
                break;
        }
    }

    [System.Obsolete]
    private void GetSetInputPlayer()
    {

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Debug.Log("Cursor Not Locked");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if(Cursor.lockState == CursorLockMode.None)
            {
                Debug.Log("Cursor Locked");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // SHIP CONTROLLER
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (ShipController.Instance.IsRideable)
            {
                Debug.Log("Now Not Rideable");
                ShipController.Instance.IsRideable = false;
            }
            else if(!ShipController.Instance.IsRideable)
            {
                Debug.Log("Now Rideable");
                ShipController.Instance.IsRideable = true;
            }
        }

        // Arrow Direction
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ArrowDirection.active)
            {
                Debug.Log("Arrow Not Active");
                ArrowDirection.SetActive(false);
            }
            else if(!ArrowDirection.active)
            {
                Debug.Log("Now Arrow Active");
                ArrowDirection.SetActive(true);
            }
        }

    }

    private void SetFirstGame()
    {
        _questState = QuestState.QSIntro;
        ArrowDirectionActive(GameObject.Find("NPC Ibu Kota"));
        QuestText.text = "Bicara dengan Kepala Desa";
    }

    private void ArrowDirectionActive(GameObject target)
    {
        Vector3 targetPos = target.transform.position;
        targetPos.y = ArrowDirection.transform.position.y;
        ArrowDirection.transform.LookAt(targetPos);
    }

    public void SetGameState(GameState state)
    {
        _gameState = state;
    }

    public void SetQuestState(QuestState state)
    {
        _questState = state;
    }

    #region Enum
    public enum GameState
    {
        Playing,
        QuestDone,
        Paused
    }

    public enum QuestState
    {
        QSIntro,
        QSDBencanaAlamBanjir,
        QSDBencanaAlamTanahLongsor,
        QSDBencanaKebakaranHutan,
        QSSimulasiBencanaAlamBanjir,
        QSSimulasiBencanaAlamTanahLongsor,
        QSSimulasiBencanaKebakaranHutan,
        QSGoodEndings,
        QSBadEndings,
    }
    #endregion
}
