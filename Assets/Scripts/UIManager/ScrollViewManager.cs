using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UIManager.Base_Script;


namespace UIManager
{
    public partial class ScrollViewManager // Properties and Methods that other classes can use
    {
        public void ToFirst() => StartCoroutine(_ToEdgeCor(true));
        
        public void ToLast() => StartCoroutine(_ToEdgeCor(false));
    }
    
    public partial class ScrollViewManager // Properties and Methods that only this class use
    {
        [SerializeField] private float lerpTime = 1f;
        
        [SerializeField] private RectTransform contentTransform;
        
        private Vector2 _sizeDelta;
        private Vector2 _first;
        private float _invLerpTime;
    }
    
    public partial class ScrollViewManager : MonoBehaviour, IUIManager
    {
        private void Start()
        {
            _sizeDelta = contentTransform.sizeDelta;
            _first = new Vector2(0, 0);
            _invLerpTime = 1 / lerpTime;
        }

        private IEnumerator _ToEdgeCor(bool isFirst)
        {
            float t = 0f;

            float start = contentTransform.anchoredPosition.x;
            float target;
            Vector2 res = new Vector2(start, 0f);
            

            if (isFirst)
            {
                target = _first.x;
            }
            else
            {
                target = -_sizeDelta.x;
            }

            while (t < 1f)
            {
                t += Time.deltaTime * _invLerpTime;
                if (t > 1f) t = 1f;

                res.x = Mathf.SmoothStep(start, target, t);
                contentTransform.anchoredPosition = res;
                yield return null;
            }
        }
    }
}


