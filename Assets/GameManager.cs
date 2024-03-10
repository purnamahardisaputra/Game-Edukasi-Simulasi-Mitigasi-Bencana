using Skripsi.Ship.MovementContoller;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text QuestText;
    public GameObject ArrowDirection;
    [SerializeField]
    private GameState _gameState;
    [SerializeField]
    private QuestState _questState;
    [SerializeField]
    private SettingsFrameRate _settingsFrameRate;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

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

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        SetProgressPlayer();
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
        // Input Player
        GetSetInputPlayer();

        // Enum
        EnumGameState(_gameState);
        EnumQuestState(_questState);
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
        if (Input.GetKeyDown(KeyCode.V))
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

    private void SetProgressPlayer()
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

    private void EnumQuestState(QuestState questState)
    {
        // QUEST STATE
        switch (questState)
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

    private void EnumGameState(GameState gameState)
    {
        // GAME STATE
        switch (gameState)
        {
            case GameState.Playing:
                break;
            case GameState.QuestDone:
                break;
            case GameState.Paused:
                break;
        }
    }

    private void EnumFrameRate(SettingsFrameRate settingsFrameRate)
    {
        switch (settingsFrameRate)
        {
            case SettingsFrameRate.FrameRate30:
                Application.targetFrameRate = 30;
                break;
            case SettingsFrameRate.FrameRate60:
                Application.targetFrameRate = 60;
                break;
            case SettingsFrameRate.FrameRate120:
                Application.targetFrameRate = 120;
                break;
            case SettingsFrameRate.FrameRate144:
                Application.targetFrameRate = 144;
                break;
            case SettingsFrameRate.FrameRate240:
                Application.targetFrameRate = 240;
                break;
        }
    }

    #region Enum
    public enum SettingsFrameRate
    {
        FrameRate30 = 30,
        FrameRate60 = 60,
        FrameRate120 = 120,
        FrameRate144 = 144,
        FrameRate240 = 240
    }

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
