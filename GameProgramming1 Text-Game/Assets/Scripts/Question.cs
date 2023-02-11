using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @author Parker Albright
 * A Scriptable Object that holds a string for the question and an array of 4 answers
 * that will be displayed when prompted.
 */
[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
  [SerializeField] string _questionText;
  public string QuestionText { get { return _questionText; } }

  [SerializeField] Answer[] _answers = new Answer[4];
  public Answer[] Answers { get { return _answers; } }

  public enum CorrectChoice
  {
    A = 0,
    B = 1,
    C = 2,
    D = 3,
    None = 4,
    All = 5
  }

  public CorrectChoice _correctChoice = CorrectChoice.None;

  public Answer GetCurrentAnswer(int index)
  {
    return _answers[index];
  }
}
