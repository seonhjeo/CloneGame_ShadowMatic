using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Rotate;
using ScriptableObj;
using UnityEngine.Profiling;


namespace GameManager
{
    public partial class GameManager // Properties and Methods that other classes can use
    {
    }

    public partial class GameManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private GameManagerSo gameData;
        
        [SerializeField]
        private List<GameObject> rotObjs = new List<GameObject>();

        [SerializeField] private UnityEvent onPlayerClear;
        [SerializeField] private UnityEvent<float> setPlayTime;
        [SerializeField] private UnityEvent<float> setProgress;

        private GameObject _curObj;
        private IRotate _curRot;

        private bool _getClear;
        private DateTime _time;
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = Instantiate(rotObjs[2], gameData.objectPos, Quaternion.identity);
            _curRot = _curObj.GetComponent<IRotate>();
            _getClear = false;
        }

        private void Start()
        {
            _curRot.InitObj();
            _time = DateTime.Now;
        }
        
        private void Update()
        {
            Profiler.BeginSample("MyCodePiece"); 
            if (!_getClear)
            {
                _SetRevolute();
                _CheckClear();
            }
            Profiler.EndSample();
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
                _getClear = true;
                TimeSpan timeSpan = DateTime.Now - _time;
                double t = timeSpan.TotalSeconds;
                float t2 = Convert.ToSingle(Math.Round(t, 2));

                onPlayerClear.Invoke();
                setPlayTime.Invoke(t2);
                setProgress.Invoke(1f);
                _curRot.RotateObjToAns(gameData.AnswerLerpTime);
            }
        }
    }
}

