using UnityEngine;
using UnityEngine.SceneManagement;

/// \brief Переход на следующую сцену
public class NewGameButton : MonoBehaviour
{
    /// Приватная переменная строкового типа, содержащая название сцены (уровня)
    [SerializeField]
    private string nameLevel = "Level1";

    /// Функция загрузки сцены по переменной nameLevel
    public void LoadHighScoreLevel()
    {
        SceneManager.LoadScene(nameLevel);
    }
}
