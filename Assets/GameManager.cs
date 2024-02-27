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
    private float zAxisPlayer;

    private void Awake()
    {
        zAxisPlayer = GameObject.Find("Main Character").transform.position.z;
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _questState = QuestState.QSIntro;
    }

    private void LateUpdate()
    {
        // lock z axis arrow direction with firs z axis main character
        ArrowDirection.transform.position = GameObject.Find("Main Character").transform.position;
    }

    private void Update()
    {
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

        switch (_questState)
        {
            case QuestState.QSIntro:
                QuestText.gameObject.SetActive(true);
                ArrowDirectionActive(GameObject.Find("NPC Ibu Kota"));
                QuestText.text = "Bicara dengan Kepala Desa";
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

    private void ArrowDirectionActive(GameObject target)
    {
        ArrowDirection.SetActive(true);
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
}
