using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes
{
    public class BaseUI : MonoBehaviour
    {
        public void Hide() {
            gameObject.SetActive(false);
        }
        public void Show() {
            gameObject.SetActive(true);
        }
    }
}
