using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReportUIManager : MonoBehaviour
{
    public GameObject reportPanel;
    public TMP_InputField inputTitle;
    public TMP_InputField inputDesc;
    public TMP_Dropdown dropdownPriority;
    public Button btnSubmit;
    public Button btnClose;
    public TextMeshProUGUI tipText;

    private Transform targetMarker;

    public void ShowPanel(Transform marker)
    {
        targetMarker = marker;
        reportPanel.SetActive(true);
        tipText.text = "";
    }

    public void OnClose()
    {
        reportPanel.SetActive(false);
    }

    public void OnSubmit()
    {
        string title = inputTitle.text;
        string desc = inputDesc.text;
        int prio = dropdownPriority.value;
        Vector3 pos = targetMarker.position;

        tipText.text = $"提交成功！位置：{pos:F2}";
        OnClose();
    }
}
