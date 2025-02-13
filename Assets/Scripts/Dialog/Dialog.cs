using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    [SerializeField] private DialogScripts _dialogScripts;

    [SerializeField] private Image _dialogImage;
    [SerializeField] private TextMeshProUGUI _dialogNameText;
    [SerializeField] private TextMeshProUGUI _dialogScriptText;

    [Header("Option")]
    [SerializeField] private float _typingSpeed;

    private Coroutine _currentTypingCoroutine;
    private Queue<DialogData> _scriptQueue = new();

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (DialogData scriptData in _dialogScripts.DialogDataList)
        {
            _scriptQueue.Enqueue(scriptData);
        }

        StartCoroutine(PrintScript());
    }

    IEnumerator PrintScript()
    {
        while(_scriptQueue.Count > 0)
        {
            DialogData scriptData = _scriptQueue.Dequeue();

            _dialogImage.sprite = scriptData.Sprite;
            _dialogNameText.text = scriptData.Name;

            string script = scriptData.Script;

            _currentTypingCoroutine = StartCoroutine(ScriptTyping(script));

            yield return new WaitUntil(() => (_currentTypingCoroutine == null || Input.GetMouseButtonUp(0)));

            if (_currentTypingCoroutine != null)
            {
                StopCoroutine(_currentTypingCoroutine);
                _currentTypingCoroutine = null;
                _dialogScriptText.text = script;
            }

            yield return new WaitForSeconds(0.1f);
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }

    IEnumerator ScriptTyping(string script)
    {
        _dialogScriptText.text = "";

        foreach (char c in script.ToCharArray())
        {
            _dialogScriptText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }

        _dialogScriptText.text = script;

        _currentTypingCoroutine = null;
    }
}
