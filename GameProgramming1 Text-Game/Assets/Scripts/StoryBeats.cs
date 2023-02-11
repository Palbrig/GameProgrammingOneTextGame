using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @author Parker Albright
 * A Scriptable Object that holds an array of strings that will be the 
 * story beats in between questions.
 */
[CreateAssetMenu(menuName ="StoryBeats")]
public class StoryBeats : ScriptableObject
{
  [TextArea]
  [SerializeField] string[] _beats;

  [SerializeField] int _beatIndex = 0;

  public string[] beats { get { return _beats; } }

  public void OnStart()
  {
    _beatIndex = 0;
  }

  public string GetBeat()
  {
    if(_beatIndex >= _beats.Length)
    {
      _beatIndex = 0;
      return "done";
    }
  
    string temp = _beats[_beatIndex];
    _beatIndex++;
    return temp;
  }
}
