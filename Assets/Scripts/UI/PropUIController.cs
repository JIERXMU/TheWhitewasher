using MizukiTool.AStar;
using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PropUIController : UIEffectController<Image>
{
    public PorpEnum Prop;
    public PointMod PointM
    {
        get
        {
            return SOManager.colorSO.GetPointMod(ColorMod);
        }
    }
    public ColorEnum ColorMod;
    public Image UIImage;
    private bool isSelected;
    private bool isScalingBigger = false;
    private ScaleEffect scaleEffectBigger;
    private ScaleEffect scaleEffectBack;
    private ScaleEffect currentScaleBiggerEffect;
    private ScaleEffect currentScaleBackEffect;

    private GameObject currentProp
    {
        get
        {
            return PorpsManager.Instance.CurrentProp;
        }
    }
    public Button button;

    void Awake()
    {
        scaleEffectBigger = new ScaleEffect()
            .SetDuration(0.2f)
            .SetEffectMode(ScaleEffectMode.Once)
            .SetEndScale(new Vector3(2f, 2f, 2f));
        scaleEffectBack = new ScaleEffect()
            .SetDuration(0.2f)
            .SetEffectMode(ScaleEffectMode.Once)
            .SetEndScale(new Vector3(1f, 1f, 1f));
    }
    void Update()
    {
        //UpdateEffect();
    }
    public void OnPointerEnter()
    {
        AmplificateSelf();
    }
    public void OnPointerExit()
    {
        ReduceSelf();
    }
    void UpdateEffect()
    {
        if (Prop != PorpEnum.Blank)
        {
            if (currentProp != null && currentProp == this.gameObject)
            {

                isSelected = true;
                AmplificateSelf();
            }
            else
            {

                isSelected = false;
                ReduceSelf();
            }
        }
    }
    public void AmplificateSelf()
    {
        Debug.Log("AmplificateSelf");
        if (currentScaleBiggerEffect != null)
        {
            currentScaleBiggerEffect.FinishImmediately();
            currentScaleBiggerEffect = null;
        }
        if (isScalingBigger)
        {
            return;
        }
        isScalingBigger = true;
        currentScaleBiggerEffect = scaleEffectBigger.Copy(scaleEffectBigger);
        StartScaleEffect(this.transform, currentScaleBiggerEffect);
    }
    public void ReduceSelf()
    {
        Debug.Log("ReduceSelf");
        if (currentScaleBackEffect != null)
        {
            currentScaleBackEffect.FinishImmediately();
            currentScaleBackEffect = null;
        }
        if (!isScalingBigger)
        {
            return;
        }
        isScalingBigger = false;
        currentScaleBackEffect = scaleEffectBack.Copy(scaleEffectBack);
        StartScaleEffect(transform, currentScaleBackEffect);
    }
    public void SetColorMod(ColorEnum colorMod)
    {
        ColorMod = colorMod;
        SetColor(colorMod);
    }
    public void SetColor(ColorEnum colorMod)
    {
        UIImage.color = SOManager.colorSO.GetColor(colorMod);
    }
    public void OnClicked()
    {
        PorpsManager.Instance.SetCurrentProp(this.gameObject);
    }

}
