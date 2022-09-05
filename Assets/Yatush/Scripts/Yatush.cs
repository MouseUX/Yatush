using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yatush
{
    public class Yatush : MonoBehaviour
    {
    #region Parameters
        public Orientation orientation;
        public FeedType feedType;
        public Display m_display;
        public Barakon m_barakon;
        private Dictionary<int, Action> MethodMap = new();
    #endregion

    #region Builtin Methods

        void Start()
        {
            TurnOn();
        }

    #endregion

    #region Custom Methods

        public void InvokeMethod(int functionIndex)
        {
            if(!MethodMap.ContainsKey(functionIndex))
                return;
            MethodMap[functionIndex].Invoke();
        }
        private void TurnOn()
        {
            switch (orientation)
            {
                case Orientation.Vertical:
                    m_display.StartVertical();
                    break;
                case Orientation.Horizontal:
                    m_display.StartHorizontal();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    #endregion
    }
}