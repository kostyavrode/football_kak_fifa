using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MobileInput : MonoBehaviour
{
    public static MobileInput instance;

    public UnityEvent onPassButtonClicked;

    public Joystick joystick;

    public Button passButton;
    public Button shootButton;
    public Button longPassButton;

    public bool isPassButtonPressed;
    public bool isShootButtonPressed;
    public bool isLongPassButtonPressed;

    private void Awake()
    {
        instance = this;
        passButton.onClick.AddListener(PassButton);
        shootButton.onClick.AddListener(ShootButton);
        longPassButton.onClick.AddListener(LongPassButton);
    }
    private void OnDisable()
    {
        passButton.onClick.RemoveListener(PassButton);
        shootButton?.onClick.RemoveListener(ShootButton);
        longPassButton?.onClick.RemoveListener(LongPassButton);
    }
    public float GetAxisHorizontal()
    {
        return joystick.Horizontal;
    }
    public float GetAxisVertical()
    {
        return joystick.Vertical;
    }
    private void PassButton()
    {
        onPassButtonClicked?.Invoke();
        isPassButtonPressed = true;
        Debug.Log("Pass Button Pressed");
    }
    private void ShootButton()
    {
        isPassButtonPressed = true;
    }
    private void LongPassButton()
    {
        isLongPassButtonPressed = true;
    }
}
