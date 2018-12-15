using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, функция которого - переход на следующую сцену
/// </summary>
public class NewGameButton : MonoBehaviour
{
    /// <summary>
    /// Приватная переменная строкового типа, содержащая название сцены (уровня)
    /// </summary>
    [SerializeField]
    private string nameLevel = "Level1";

    /// <summary>
    /// Функция загрузки сцены по переменной nameLevel
    /// </summary>
    public void LoadHighScoreLevel()
    {
        SceneManager.LoadScene(nameLevel);
    }
}
