using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenge : MonoBehaviour
{
    [SerializeField] string Scene;
    public GameObject Button;

    public void OnClickButton()
    {
        ChengeScene();
    }

    void ChengeScene() 
    {
        SceneManager.LoadScene(Scene);
    }
}
