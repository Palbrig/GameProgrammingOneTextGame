using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{
  Camera _cam;

  private void Awake()
  {
    _cam = GetComponent<Camera>();  
  }

  public void ChangeColor()
  {
    _cam.backgroundColor = Color.red;
  }
  public void ChangeColor(float r, float g, float b, float a)
  {
    _cam.backgroundColor = new Color(r,g,b,a);
  }
}
