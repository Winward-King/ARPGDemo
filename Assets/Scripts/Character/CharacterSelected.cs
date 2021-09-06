using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character
{
    /// <summary>
    /// 角色选择器
    /// </summary>
    public class CharacterSelected : MonoBehaviour
    {
        private GameObject selectedGO;
        [Tooltip("选择器游戏物体名称")]
        public string selectedName = "selected";
        [Tooltip("显示时间")]
        public float displayTime = 3;
        private void Start()
        {
            selectedGO = transform.Find(selectedName).gameObject;
        }

        private float hideTime;
        public void SetSelectedActive(bool state)
        {
            //设置选择器物体激活状态
            selectedGO.SetActive(state);
            //设置当前脚本激活状态(开启/停止Update调用)
            this.enabled = state;
            if (state)
                hideTime = Time.time + displayTime;
        }

        private void Update()
        {
            if (hideTime <= Time.time)
            {
                SetSelectedActive(false);
            }
        }
    }
}