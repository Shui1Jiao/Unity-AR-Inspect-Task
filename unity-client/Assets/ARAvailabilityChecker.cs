using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARSession))]
public class ARAvailabilityChecker : MonoBehaviour
{
    void Awake()
    {
        ARSession.stateChanged += OnSessionStateChanged;
    }

    void Start()
    {
        CheckARSupport();
    }

    void CheckARSupport()
    {
        //不支持ARCore就跳转到虚拟场景，注意场景名字要和你Build Settings里写的完全一致！
        if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.Unsupported)
        {
            SceneManager.LoadScene("VirtualDemo");
        }
    }

    void OnSessionStateChanged(ARSessionStateChangedEventArgs args)
    {
        if (args.state == ARSessionState.Unsupported)
        {
            SceneManager.LoadScene("VirtualDemo");
        }
    }

    void OnDestroy()
    {
        ARSession.stateChanged -= OnSessionStateChanged;
    }
}
