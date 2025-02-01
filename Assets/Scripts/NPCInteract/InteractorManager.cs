using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MizukiTool.Interact
{
    /// <summary>
    /// 注意给能够交互的目标添加一个交互标记InteractorMark
    /// </summary>
    public static class InteractorManager
    {
        public static bool Interacting = false;

        public static InteractorMark InteractableTarget;
        public static string IconPrePath = "Prefeb/InteractableIcon/InteractableIcon";
        public static void UpdateInteractableTarget(InteractorMark interactorMark)
        {
            if (InteractableTarget)
            {
                InteractableTarget.icon.SetActive(false);
            }
            InteractableTarget = interactorMark;
        }

        public static void RemoveInteractableTarget(InteractorMark interactorMark)
        {
            if (InteractableTarget == interactorMark)
            {
                InteractableTarget = null;
            }
        }
        /// <summary>
        /// 获取当前交互目标
        /// </summary>
        /// <returns>返回当前交互目标</returns>
        public static GameObject GetInteractableTarget()
        {
            if (InteractableTarget)
            {
                return InteractableTarget.gameObject;
            }
            return null;
        }
    }
}
