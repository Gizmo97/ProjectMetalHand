using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private LevelSystem levelSystem;
    private int LMxp;
    private int HLBxp;
    private int RGxp;
    private int LMmaxXp;
    private int HLBmaxXp;
    private int RGmaxXp;
    private int LMlevel;
    private int HLBlevel;
    private int RGmlevel;
    private int LMmaxlevel;
    private int HLBmaxlevel;
    private int RGmaxlevel;

    public LevelSystem()
    {
        LMlevel = 1;
        HLBlevel = 1;
        RGmlevel = 1;
        LMmaxlevel = 1;
        HLBmaxlevel = 1;
        RGmaxlevel = 1;
        LMxp = 0;
        HLBxp = 0;
        RGxp = 0;
        LMmaxXp = 500;
        HLBmaxXp = 500;
        RGmaxXp = 1000;
    }

    public void AddXP (int XP)
    {
        LMxp += XP;
        if (LMxp >= LMmaxXp)
        {
            LMlevel++;
            LMxp -= LMmaxXp;
        }

    }
}
