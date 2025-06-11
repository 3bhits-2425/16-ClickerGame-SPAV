using UnityEngine;

public class Apple : MonoBehaviour
{
    public ClickerGame clickerGame;

    private void OnMouseDown()
    {
        clickerGame.IncreaseScore();
        Debug.Log("Apple clicked! Score increased.");
        Destroy(gameObject);
    }
}
