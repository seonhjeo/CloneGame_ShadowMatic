using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Rotate;
using ScriptableObj;

namespace GameManager
{
    public enum GameState
    {
        Start = 1,
        Play = 2,
        OnUI = 3,
        Clear = 4
    }
    
    
    public partial class GameManager // Properties and Methods that other classes can use
    {
        public LoadLevelSo loadLevelData;
        
        public GameState GameState { get; private set; } = GameState.Start;

        public void ToUIState(float delay) => _SetGameState(GameState.OnUI, delay);
        public void ToPlayState(float delay) => _SetGameState(GameState.Play, delay);
    }

    public partial class GameManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private GameManagerSo gameData;
        
        [SerializeField]
        private List<GameObject> rotObjs = new List<GameObject>();
        
        [SerializeField] private UnityEvent<float, float> setResult;
        [SerializeField] private UnityEvent<float> setProgress;

        private GameObject _curObj;
        private IRotate _curRot;

        private bool _getClear;
        private float _clearTime;
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = Instantiate(rotObjs[loadLevelData.levelToLoad], gameData.objectPos, Quaternion.identity);
            _curRot = _curObj.GetComponent<IRotate>();
            _clearTime = 0f;
        }

        private void Start()
        {
            #if UNITY_IOS || UNITY_ANDROID
                Application.targetFrameRate = 60;
            #else
                QualitySettings.vSyncCount = 1;
            #endif
            
            _curRot.InitObj();
            GameState = GameState.Play;
        }
        
        private void Update()
        {
            if (GameState == GameState.Play)
            {
                _clearTime += Time.deltaTime;
            }
            
            if (!_getClear)
            {
                _SetRevolute();
                _CheckClear();
            }
        }
    }

    //class body
    public partial class GameManager
    {
        // Control Input
        private void _SetRevolute()
        {
            if (_curRot.Type == RotateTypes.Revoluter)
            {
                if (Input.GetButtonDown("Revolute"))
                {
                    _curRot.ActivateObject(true);
                }
                else if (Input.GetButtonUp("Revolute"))
                {
                    _curRot.ActivateObject(false);
                }
            }
        }

        private void _CheckClear()
        {
            float res = _curRot.ReturnProgress();
            setProgress.Invoke(res);
            if (res >= gameData.Offset)
            {
                GameState = GameState.Clear;
                setResult.Invoke(_clearTime, gameData.AnswerLerpTime);
                setProgress.Invoke(1f);
                _curRot.RotateObjToAns(gameData.AnswerLerpTime);
            }
        }

        private void _SetGameState(GameState state, float delay = 0f)
        {
            StartCoroutine(_SetGameStateIE(state, delay));
        }

        private IEnumerator _SetGameStateIE(GameState state, float delay)
        {
            if (delay != 0f)
            {
                yield return new WaitForSeconds(delay);
            }
            
            GameState = state;
        }
    }
}

