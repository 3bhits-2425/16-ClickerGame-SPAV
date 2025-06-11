using UnityEngine;

public class Apple : MonoBehaviour
{
    public ClickerGame clickerGame;

    private void OnMouseDown()
    {
        clickerGame.IncreaseScore();
        Destroy(gameObject);
    }
}
