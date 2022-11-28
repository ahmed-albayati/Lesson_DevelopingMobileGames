using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int score;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    private void Start()
    {
        updateCount();
    }
    void OnEnable() => Collectable.OnCollect += OnCollectableCollected;
    void OnDisable() => Collectable.OnCollect -= OnCollectableCollected;

    void OnCollectableCollected() {
        text.text = (++score).ToString();
        updateCount();
    }
    void updateCount() {
        text.text = $"{score}";
    }
}
