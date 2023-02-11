using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @author Parker Albright
 * A Scriptable Object that accompanies the Question SO which is a string
 * and a bool notating if it is the correct answer or not.
 */
[CreateAssetMenu(menuName ="Answer")]
public class Answer : ScriptableObject
{
  [SerializeField] private Question.CorrectChoice _choice;
  public Question.CorrectChoice Choice {  get { return _choice; } set { _choice = value; } }

  [SerializeField] string _answerText;
  public string AnswerText
  {
    get
    {
      switch (_choice)
      {
        case Question.CorrectChoice.A:
          return "A: " + _answerText;
        case Question.CorrectChoice.B:
          return "B: " + _answerText;
        case Question.CorrectChoice.C:
          return "C: " + _answerText;
        case Question.CorrectChoice.D:
          return "D: " + _answerText;
        default:
          return _answerText;
      }
    }
  }
}
