using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

public class TimelineShots : MonoBehaviour
{
    public List< PlayableDirector> m_playableDirectors;
    public List<TimelineAsset> m_timeLines;

    public void Play()
    {
        foreach (PlayableDirector playable in m_playableDirectors)
        {
            playable.Play();
        }
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedTimeline;

        if (m_timeLines.Count <= index)
        {
            selectedTimeline = m_timeLines[m_timeLines.Count - 1];
            Debug.Log("Index greater");
        }
        else
        {
            selectedTimeline = m_timeLines[index];
            Debug.Log("m_timeLines.Count >= index-------" + selectedTimeline);
        }





        //int selectedTimelineIndex;
        //if (m_timeLines.Count <= index)
        //{
        //    selectedTimelineIndex = m_timeLines.Count - 1;
        //    Debug.Log("Index greater");
        //}
        //else
        //{
        //    selectedTimelineIndex = index;
        //    Debug.Log("m_timeLines.Count >= index-------" + selectedTimelineIndex);
        //}

        m_playableDirectors[index].Play(selectedTimeline);  
    }
}
