using System.Collections;
using System.Collections.Generic;
using MizukiTool.Box;
using UnityEngine;

public class LevelSelectUI : GeneralBox<LevelSelectUI, string, string>
{
    public RectTransform LevelScelectContent;
    void Start()
    {
        InitLevelSelectUI();
    }
    public override void GetParams(string param)
    {
        this.param = param;
    }
    public override string SendParams()
    {
        return "关闭UI";
    }
    public void OnReturnBtnClicked()
    {
        Close();
    }
    public void InitLevelSelectUI()
    {
        //初始化关卡选择界面
        for (int i = 0; i < 8; i++)
        {
            GameObject levelBtn = Instantiate(Resources.Load<GameObject>("Prefeb/UIPrefeb/LevelSelectItem"));
            LevelSelectItem levelScelectItem = levelBtn.GetComponent<LevelSelectItem>();
            levelBtn.transform.SetParent(LevelScelectContent);
            levelBtn.transform.localScale = Vector3.one;
            levelScelectItem.SetLevelText((i + 1).ToString());
            levelScelectItem.SetTargetScene((SceneEnum)System.Enum.Parse(typeof(SceneEnum), "Level" + (i + 1)));
            levelScelectItem.OnLevelSelectItemClicked = () =>
            {
                Close();
            };
            if (i >= GamePlayManager.TopUnlockedLevel)
            {
                levelScelectItem.SetLock();
            }
        }
    }
}
