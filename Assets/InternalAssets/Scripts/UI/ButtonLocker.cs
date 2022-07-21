using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLocker : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    public void LockButtons()
    {
        foreach (var button in buttons)
        {
            button.enabled = false;
        }
    }

    public void UnlockButtons()
    {
        foreach (var button in buttons)
        {
            button.enabled = true;
        }
    }
}
