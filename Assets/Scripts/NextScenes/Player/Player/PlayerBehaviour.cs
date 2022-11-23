using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public Animator animatorOfPlayer;

    public PlayerMoverRunner playerMoverRunner;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion
    public void StopPlayer()
    {
        playerMoverRunner.Velocity = 0;
        DOTween.To(() => playerMoverRunner.Velocity, x => playerMoverRunner.Velocity = x, 0, 0.003f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
