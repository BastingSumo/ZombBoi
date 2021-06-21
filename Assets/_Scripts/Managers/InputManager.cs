using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    static KeyCode Up = KeyCode.W;
    static KeyCode Down = KeyCode.S;
    static KeyCode Left = KeyCode.A;
    static KeyCode Right = KeyCode.D;
    static KeyCode Sprint = KeyCode.LeftShift;
    static KeyCode Shoot = KeyCode.Mouse0;
    static KeyCode OpenInventory = KeyCode.Tab;
    static KeyCode Reload = KeyCode.R;
    static KeyCode Interact = KeyCode.E;
    static KeyCode BarSwitchRight = KeyCode.V;
    static KeyCode BarSwitchLeft = KeyCode.C;

    static KeyCode HotBarOne = KeyCode.Alpha1;
    static KeyCode HotBarTwo = KeyCode.Alpha2;
    static KeyCode HotBarThree = KeyCode.Alpha3;
    static KeyCode HotBarFour = KeyCode.Alpha4;
    static KeyCode HotBarFive = KeyCode.Alpha5;
    static KeyCode HotBarSix = KeyCode.Alpha6;
    static KeyCode HotBarSeven = KeyCode.Alpha7;
    static KeyCode HotBarEight = KeyCode.Alpha8;
    static KeyCode HotBarUnAssign = KeyCode.F;


    public static bool hasPressedTilde()
    {
        if (Input.GetKeyUp(HotBarUnAssign)) return true;
        return false;
    }
    public static bool hasPressedOne()
    {
        if (Input.GetKeyUp(HotBarOne)) return true;
        return false;
    }
    public static bool hasPressedTwo()
    {
        if (Input.GetKeyUp(HotBarTwo)) return true;
        return false;
    }
    public static bool hasPressedThree()
    {
        if (Input.GetKeyUp(HotBarThree)) return true;
        return false;
    }
    public static bool hasPressedFour()
    {
        if (Input.GetKeyUp(HotBarFour)) return true;
        return false;
    }
    public static bool hasPressedFive()
    {
        if (Input.GetKeyUp(HotBarFive)) return true;
        return false;
    }
    public static bool hasPressedSix()
    {
        if (Input.GetKeyUp(HotBarSix)) return true;
        return false;
    }
    public static bool hasPressedSeven()
    {
        if (Input.GetKeyUp(HotBarSeven)) return true;
        return false;
    }
    public static bool hasPressedEight()
    {
        if (Input.GetKeyUp(HotBarEight)) return true;
        return false;
    }
    public static bool hasPressedBarSwitchLeft()
    {
        if (Input.GetKeyUp(BarSwitchLeft)) return true;
        return false;
    }
    public static bool hasPressedBarSwitchRight()
    {
        if (Input.GetKeyUp(BarSwitchRight)) return true;
        return false;
    }
    public static bool isPressingUp()
    {
        if (Input.GetKey(Up) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool isPressingDown()
    {
        if (Input.GetKey(Down) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool isPressingLeft()
    {
        if (Input.GetKey(Left) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool isPressingRight()
    {
        if (Input.GetKey(Right) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool isMoving()
    {
        if (!PlayerInventory.Instance.InventoryIsOpen())
        {
            if (isPressingUp() || isPressingDown() || isPressingLeft() || isPressingRight()) return true;
        }
        return false;
    }
    public static bool isPressingSprint()
    {
        if (Input.GetKey(Sprint) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool isShooting()
    {
        if (Input.GetKey(Shoot) && !PlayerInventory.Instance.InventoryIsOpen()) return true;
        return false;
    }
    public static bool hasPressedInventoryKey()
    {
        if (Input.GetKeyDown(OpenInventory))
        {
            return true;
        }
        return false;
    }
    public static bool hasPressedReload()
    {
        if (Input.GetKeyDown(Reload) && !PlayerInventory.Instance.InventoryIsOpen())
        {
            return true;
        }
        return false;
    }
    public static bool hasPressedInteract()
    {
        if (Input.GetKeyDown(Interact) && !PlayerInventory.Instance.InventoryIsOpen())
        {
            return true;
        }
        return false;
    }
}
