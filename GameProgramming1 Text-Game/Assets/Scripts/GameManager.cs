using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Parker Albright
 * This manages the games states and sets all the correct text when needed.
 */
public class GameManager : MonoBehaviour
{
  [SerializeField] TMPro.TMP_Text _storyTMP;
  [SerializeField] TMPro.TMP_Text _questionTMP;
  [SerializeField] TMPro.TMP_Text[] _answersTMP;
  [SerializeField] Canvas _storyCanvas;
  [SerializeField] Canvas _questionCanvas;
  [SerializeField] Camera _mainCam;

  [SerializeField] StoryBeats[] _gamesStoryBeats;
  [SerializeField] StoryBeats[] _postQuestionCorrectAnswers;
  [SerializeField] StoryBeats[] _postQuestionIncorrectAnswers;
  [SerializeField] Question[] _gamesQuestions;

  [SerializeField] StoryBeats _curStoryBeat;
  [SerializeField] int _storyIndex = 0;

  [SerializeField] Question _curQuestion;
  [SerializeField] int _questionIndex = 0;

  [SerializeField] int _correctAnswers = 0;

  [SerializeField] bool _isReading = true;

  private void Start()
  {
    _storyIndex = 0;
    _questionIndex = 0;
    _correctAnswers = 0;

    foreach(StoryBeats beat in _gamesStoryBeats)
    {
      beat.OnStart();
    }
    foreach (StoryBeats beat in _postQuestionCorrectAnswers)
    {
      beat.OnStart();
    }
    foreach (StoryBeats beat in _postQuestionIncorrectAnswers)
    {
      beat.OnStart();
    }

    InitReadingState();
    NextReadingState();
    ReadingStateUpdate();
  }

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.RightArrow) && _isReading == true)
    {
      DisplayNextBeat();
    }
    if(_isReading == false)
    {
      AnswerQuestion();
    }
  }

  //Will display the text and story correctly when needed.
  private void InitReadingState()
  {
    if (_questionCanvas.enabled == true)
      _questionCanvas.enabled = false;
    if (_storyCanvas.enabled == false)
      _storyCanvas.enabled = true;
  }
  private void NextReadingState()
  {
    _curStoryBeat = _gamesStoryBeats[_storyIndex];
    _storyIndex++;
  }
  private void ReadingStateUpdate()
  {
    _storyTMP.text = _curStoryBeat.GetBeat();
  }

  private void InitQuestionState()
  {
    if (_questionCanvas.enabled == false)
      _questionCanvas.enabled = true;
    if (_storyCanvas.enabled == true)
      _storyCanvas.enabled = false;

    _curQuestion = _gamesQuestions[_questionIndex];
    _questionTMP.text = _curQuestion.QuestionText;
    
    if(_curQuestion.Answers.Length < 4)
    {
      for (int i = 0; i < _answersTMP.Length; i++)
      {
        _answersTMP[i].text = "";
      }

      for (int i = 0; i < _curQuestion.Answers.Length; i++)
      {
        _answersTMP[i].text = _curQuestion.GetCurrentAnswer(i).AnswerText;
      }
    }
    else
    {
      for (int i = 0; i < _answersTMP.Length; i++)
      {
        _answersTMP[i].text = _curQuestion.GetCurrentAnswer(i).AnswerText;
      }
    }

    SetColor();
  }

  private void DisplayNextBeat()
  {
    string temp = _curStoryBeat.GetBeat();
    if(temp != "done")
    {
      _storyTMP.text = temp;
    }
    else
    {
      NextReadingState();
      _isReading = false;
      InitQuestionState();
    }
  }

  private void AnswerQuestion()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      if (_curQuestion._correctChoice == Question.CorrectChoice.A || _curQuestion._correctChoice == Question.CorrectChoice.All)
      {
        _correctAnswers++;
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      else
      {
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      Debug.Log($"Correct answer score {_correctAnswers}");
      _isReading = true;
      _questionIndex++;
    }
    if (Input.GetKeyDown(KeyCode.B))
    {
      if (_curQuestion._correctChoice == Question.CorrectChoice.B || _curQuestion._correctChoice == Question.CorrectChoice.All)
      {
        _correctAnswers++;
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      else
      {
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      Debug.Log($"Correct answer score {_correctAnswers}");
      _isReading = true;
      _questionIndex++;
    }
    if (Input.GetKeyDown(KeyCode.C))
    {
      if (_curQuestion._correctChoice == Question.CorrectChoice.C || _curQuestion._correctChoice == Question.CorrectChoice.All)
      {
        _correctAnswers++;
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      else
      {
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      Debug.Log($"Correct answer score {_correctAnswers}");
      _isReading = true;
      _questionIndex++;
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
      if (_curQuestion._correctChoice == Question.CorrectChoice.D || _curQuestion._correctChoice == Question.CorrectChoice.All)
      {
        _correctAnswers++;
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      else
      {
        InitReadingState();
        _curStoryBeat = _postQuestionCorrectAnswers[_questionIndex];
        ReadingStateUpdate();
      }
      Debug.Log($"Correct answer score {_correctAnswers}");
      _isReading = true;
      _questionIndex++;
    }
    return;
  }

  private void SetColor()
  {
    float r = (_questionIndex + 1) * .1f;
    float g = .5f - ((_questionIndex + 1) * .05f);
    float b = 1 - ((_questionIndex + 1) * .1f);
    float a = 1;

    Debug.Log($"Setting color to the value of red: {r} green: {g} blue: {b} alpha: {a}");

    _mainCam.GetComponent<ChangeBGColor>().ChangeColor(r, g, b, a);
  }

  private void EndingLoop()
  {
    /*
     * One the player hits the end of questions it'll loop the final question 
     * forever between answer and what not.
     */
  }

  private void FadeInBGImage()
  {
    /*
     * Around question 5 or 6 when things start getting weird a background image
     * will slowly fade in. Possibly a wall of text saying "get out" or 
     * "it's over".
     * 
     * Inspiration mother 2's weird boss fetus thingy and possibly animate it if I 
     * really have time.
     */
  }
}