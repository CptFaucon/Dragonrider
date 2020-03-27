using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[RequireComponent(typeof(AudioSource))]

public class VoiceLineInGameManager : MonoBehaviour
{
    [SerializeField] private GameObject VoiceLineBox;
    private TextMeshProUGUI text;
    [SerializeField] private string[] voiceLineTexts;
    [SerializeField] private AudioClip[] voiceLineAudios;

    private AudioSource speaker;

    private void Awake()
    {
        speaker = GetComponent<AudioSource>();
        text = VoiceLineBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void VoiceLine(int voiceLine)
    {
        VoiceLineBox.SetActive(true);
        text.text = voiceLineTexts[voiceLine];
        speaker.PlayOneShot(voiceLineAudios[voiceLine]);
        StartCoroutine(CloseVoiceLine());
    }

    private IEnumerator CloseVoiceLine()
    {
        while (speaker.isPlaying) {

            yield return null;
        }

        yield return new WaitForSeconds(.5f);
        VoiceLineBox.SetActive(false);
    }
}
