using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneTrigger : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        hasTriggered = true;
        SceneManager.LoadScene(targetSceneName);
    }
}