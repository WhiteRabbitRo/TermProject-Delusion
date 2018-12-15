using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    [SerializeField]
    private string nameOfLevel = "Level";

    private Animator animator;
    private SpriteRenderer sprite;

    private PortalState State
    {
        get { return (PortalState)animator.GetInteger("State") + 1; }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        State = PortalState.MeetPlayer;
    }

    void Update ()
    {
        State = PortalState.WaitPlayer;
    }

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

public enum PortalState
{
    MeetPlayer,
    WaitPlayer,
    BringPlayer
}