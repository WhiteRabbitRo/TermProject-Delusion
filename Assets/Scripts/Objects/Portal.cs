using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// \brief Портал
/// Перемещение игрока при вхождении в портал
public class Portal : MonoBehaviour {

    [SerializeField]
    private string nameOfLevel = "Level"; /// Название загружаемого уровня

    private Animator animator; /// Компонент с анимацией
    private SpriteRenderer sprite; /// Компонент "спрайт"

    private PortalState State /// Мэнэджер анимации
    {
        get { return (PortalState)animator.GetInteger("State") + 1; }
        set { animator.SetInteger("State", (int)value); }
    }

    /// Получение компонентов
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        State = PortalState.MeetPlayer;
    }

    /// Включение анимации "Ожидание игрока"
    void Update ()
    {
        State = PortalState.WaitPlayer;
    }

    /// При вхождении в коллайдер портала игрока - переключить анимацию
    /// и загрузить новый уровень
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            Destroy(character);
            State = PortalState.BringPlayer;
            SceneManager.LoadScene(nameOfLevel);
        }
    }

}

/// Стадии анимации портала
public enum PortalState
{
    MeetPlayer, /// < Встреча с игроком
    WaitPlayer, /// < Ожидание игрока
    BringPlayer /// < Перенос игрока
}