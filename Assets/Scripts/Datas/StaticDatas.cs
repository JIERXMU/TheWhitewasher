public static class StaticDatas
{
    public static SceneEnum CurrentScene;
    public static int MaxLevel = 1;
    public static bool IsPlayerFinishAllLevel
    {
        get
        {
            return MaxLevel > 8;
        }
    }
    /// <summary>
    /// 单个方块的染色时间
    /// </summary> 
    public static float ColorFadeTime = 1f;
    /// <summary>
    /// 染色的传播速率 例如2f表示在ColorFadeTime内颜色会向外传播2个方块
    /// </summary>
    public static float FadeSpradeSpeed = 6f;
    public static bool IsBeginCGShown = false;
    public static bool IsDialogCGShown = false;
    public static bool IsSpecialCGShown = false;
    public static bool IsEndCGShowm = false;
}
