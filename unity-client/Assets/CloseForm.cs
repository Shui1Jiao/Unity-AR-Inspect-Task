using UnityEngine;

public class CloseForm : MonoBehaviour
{
    public GameObject formPanel;

    public void HideForm()
    {
        formPanel.SetActive(false);
    }
}
