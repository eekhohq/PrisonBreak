using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    private string riddle;
    private string answer;
    private bool solved = false;

    public PuzzleItem(string name, float weight, string riddle, string answer/*, bool solved = false*/) : base(name, weight)
    {
        this.riddle = riddle;
        this.answer = answer;
        /*this.solved = solved;*/
    }

    public string GetRiddle()
    {
        return riddle;
    }

    public string GetAnswer()
    {
        return answer;
    }

    public bool IsSolved(string pAnswer = null)
    {
        if(answer.ToLower() == pAnswer.ToLower())
        {
            solved = true;
        }
        return solved;
    }
}
