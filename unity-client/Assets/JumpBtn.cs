using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpBtn : MonoBehaviour
{
    private Button btn;
    void Awake()
    {
        // 获取自身的Button组件
        btn = GetComponent<Button>();
        // 代码自动绑定点击事件，不需要Inspector设置On Click
        btn.onClick.AddListener(OnClickJump);
    }

    void OnClickJump()
    {
        Debug.Log("🔴点击跳转虚拟演示");
        SceneManager.LoadScene("VirtualDemo");
    }
}
