using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button btnARMode;
    public Button btnVirtualMode;

    void Start()
    {
        if (btnARMode != null)
        {
            btnARMode.onClick.AddListener(GoARMode);
            Debug.Log("✅AR按钮绑定成功");
        }
        if (btnVirtualMode != null)
        {
            btnVirtualMode.onClick.AddListener(GoVirtualDemo);
            Debug.Log("✅虚拟按钮绑定成功");
        }
    }

    public void GoARMode()
    {
        Debug.Log("点击：进入AR场景");
        SceneManager.LoadScene(1);
    }
    public void GoVirtualDemo()
    {
        Debug.Log("点击：进入虚拟演示场景");
        SceneManager.LoadScene(2);
    }
}
