using System;
using UnityEngine;
using UnityEngine.UI;

namespace Yatush
{
    public class Buttons : MonoBehaviour
    {
        private void Start()
        {
            var images = GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                image.color = new Color(0, 0, 0, 0);
            }
        }
    }
}