using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeEffect : UIEffectController<Image>
{
    private PositionEffect rightPositionEffect;
    private PositionEffect leftPositionEffect;
    public Transform RightGO;
    public Transform LeftGO;
    public void SetSceneInEffect()
    {
        RightGO.transform.localPosition = new Vector3(720 * 2, 0, 0);
        rightPositionEffect = new PositionEffect()
            .SetEffectMode(PositionEffectMode.Once)
            .SetEndPosition(transform.position + new Vector3(720, 0, 0))
            .SetDuration(0.5f);
        LeftGO.transform.localPosition = new Vector3(-720 * 2, 0, 0);
        leftPositionEffect = new PositionEffect()
            .SetEffectMode(PositionEffectMode.Once)
            .SetEndPosition(transform.position + new Vector3(-720, 0, 0))
            .SetDuration(0.5f);
        StartPositionEffect(RightGO, rightPositionEffect);
        StartPositionEffect(LeftGO, leftPositionEffect);
    }

    public void SetSceneOutEffect()
    {
        RightGO.transform.localPosition = new Vector3(0, 0, 0);
        rightPositionEffect = new PositionEffect()
            .SetEffectMode(PositionEffectMode.Once)
            .SetEndPosition(transform.position + new Vector3(720 * 2, 0, 0))
            .SetDuration(0.5f);
        LeftGO.transform.localPosition = new Vector3(0, 0, 0);
        leftPositionEffect = new PositionEffect()
            .SetEffectMode(PositionEffectMode.Once)
            .SetEndPosition(transform.position + new Vector3(-720 * 2, 0, 0))
            .SetDuration(0.5f);
        StartPositionEffect(RightGO, rightPositionEffect);
        StartPositionEffect(LeftGO, leftPositionEffect);
    }
}
