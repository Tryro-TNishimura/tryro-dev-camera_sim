using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProportionalScaler : MonoBehaviour
{
    [System.Serializable]
    public class DimensionControl
    {
        public TMP_Text labelText;
        public Button plusButton;
        public Button minusButton;
        public float value = 1f;
        [HideInInspector] public float previousValue; // 新規追加
    }

    public DimensionControl width;
    public DimensionControl height;
    public DimensionControl depth;

    public Toggle ratioToggle;
    public float step = 0.1f;

    private bool isUpdating = false; // 再帰防止用

    void Start()
    {
        SetupDimension(width, () => OnValueChanged(width));
        SetupDimension(height, () => OnValueChanged(height));
        SetupDimension(depth, () => OnValueChanged(depth));

        UpdateAllTexts();
    }

    void SetupDimension(DimensionControl dim, System.Action onChange)
    {
        dim.plusButton.onClick.AddListener(() =>
        {
            dim.previousValue = dim.value;  // ボタン押下前の値を保存
            dim.value = Mathf.Round((dim.value + step) * 10f) / 10f;
            onChange();
        });

        dim.minusButton.onClick.AddListener(() =>
        {
            dim.previousValue = dim.value;  // ボタン押下前の値を保存
            dim.value = Mathf.Round(Mathf.Max(0.1f, dim.value - step) * 10f) / 10f;
            onChange();
        });
    }

    void OnValueChanged(DimensionControl source)
    {
        if (isUpdating) return;

        if (ratioToggle.isOn)
        {
            isUpdating = true;

            float ratio = source.value / source.previousValue;

            if (source == width)
            {
                height.value *= ratio;
                depth.value *= ratio;
            }
            else if (source == height)
            {
                width.value *= ratio;
                depth.value *= ratio;
            }
            else if (source == depth)
            {
                width.value *= ratio;
                height.value *= ratio;
            }

            isUpdating = false;
        }

        UpdateAllTexts();
    }

    void UpdateAllTexts()
    {
        width.value = Mathf.Round(width.value * 10f) / 10f;
        height.value = Mathf.Round(height.value * 10f) / 10f;
        depth.value = Mathf.Round(depth.value * 10f) / 10f;

        width.labelText.text = width.value.ToString("F1");
        height.labelText.text = height.value.ToString("F1");
        depth.labelText.text = depth.value.ToString("F1");
    }
}