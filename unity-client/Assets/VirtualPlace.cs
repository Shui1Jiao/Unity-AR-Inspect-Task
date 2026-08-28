using UnityEngine;

public class VirtualPlace : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject uiFormInstance;

    void Awake()
    {
        Debug.Log("🟢VirtualPlace脚本已经启动！");
    }

    void Update()
    {
        bool trigger = false;
        Vector2 screenPos = Vector2.zero;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            trigger = true;
            screenPos = Input.mousePosition;
            Debug.Log("✅检测到鼠标按下");
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            trigger = true;
            screenPos = Input.GetTouch(0).position;
            Debug.Log("✅检测到触屏按下");
        }
#endif

        if (trigger)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log($"点击命中位置 {hit.point} 对象:{hit.collider.gameObject.name}");
                if (ballPrefab != null)
                {
                    Instantiate(ballPrefab, hit.point, Quaternion.identity);
                }
                if (uiFormInstance != null)
                {
                    uiFormInstance.SetActive(true);
                }
            }
            else
            {
                Debug.Log("❌射线没有碰撞到物体");
            }
        }
    }
}
