using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{
    public void GoToVirtualDemo()
    {
        SceneManager.LoadScene("VirtualDemo");
    }
}
