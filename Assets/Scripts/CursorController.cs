using UnityEngine;

public static class CursorController
{
    private static bool cursorLocked;

    public static void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
    }

    public static void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cursorLocked = false;
    }

    public static void ChangeMode()
    {
        if (cursorLocked) UnlockCursor();
        else LockCursor();
    }
}
