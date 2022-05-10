using System;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 618
namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // an incredibly simple menu which, when given references
        // to gameobjects in the scene
        public Text camswitchbutton;
        public GameObject[] objects;


        private int m_currentactiveobject;


        private void onenable()
        {
            // active object starts from first in array
            m_currentactiveobject = 0;
            camswitchbutton.text = objects[m_currentactiveobject].name;
        }


        public void nextcamera()
        {
            int nextactiveobject = m_currentactiveobject + 1 >= objects.Length ? 0 : m_currentactiveobject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_currentactiveobject = nextactiveobject;
            camswitchbutton.text = objects[m_currentactiveobject].name;
        }
    }
}
