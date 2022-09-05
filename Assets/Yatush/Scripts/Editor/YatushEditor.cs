using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Yatush.Editor
{
    [CustomEditor(typeof(Yatush))]
    public class YatushEditor : UnityEditor.Editor
    {
        public Orientation currentOrientation;
        public FeedType currentFeedType;
        public Yatush yatush;

        private void OnEnable()
        {
            yatush = target as Yatush;
            SetDisplayOrientation();
        }


        public override void OnInspectorGUI()
        {
            serializedObject.ApplyModifiedProperties();

            yatush.orientation = (Orientation)EditorGUILayout.EnumPopup("Orientation", yatush.orientation);
            yatush.feedType = (FeedType)EditorGUILayout.EnumPopup("Feed Type", yatush.feedType);
            

            yatush.m_display =
                EditorGUILayout.ObjectField("Display", yatush.m_display, typeof(Display), true) as Display;

            yatush.m_barakon =
                EditorGUILayout.ObjectField("Barakon", yatush.m_barakon, typeof(Barakon), true) as Barakon;

            if (currentOrientation != yatush.orientation)
                SetDisplayOrientation();

            if (currentFeedType != yatush.feedType)
                SetColorFeed();
            
            if (GUI.changed)
            {
                EditorUtility.SetDirty(yatush);
                EditorSceneManager.MarkSceneDirty(yatush.gameObject.scene);
            }
        }

        private void SetColorFeed()
        {
            var display = yatush.m_display;

            if (display == null)
                return;
            
            switch (yatush.feedType)
            {
                case FeedType.BlackAndWhite:
                    display.SetMaterial(display.Grayscale);
                    break;
                case FeedType.Colored:
                    display.SetMaterial(display.Colored);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            currentFeedType = yatush.feedType;
        }

        private void SetDisplayOrientation()
        {
            var display = yatush.m_display;


            if (display == null)
                return;

            switch (yatush.orientation)
            {
                case Orientation.Vertical:
                    display.StartVertical();
                    break;
                case Orientation.Horizontal:
                    display.StartHorizontal();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            currentOrientation = yatush.orientation;
        }
    }
}