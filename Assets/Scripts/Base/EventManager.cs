using System;
using System.Collections.Generic;

public class EventManager
{
    private static Dictionary<EventId, List<Action<object[]>>> eventList = new Dictionary<EventId, List<Action<object[]>>>();

    public static void AddEvent(EventId id, Action<object[]> cb)
    {
        if (eventList.ContainsKey(id))
        {
            eventList[id].Add(cb);
        }
        else
        {
            List<Action<object[]>> cbList = new List<Action<object[]>>();
            cbList.Add(cb);
            eventList.Add(id, cbList);
        }
    }

    public static void RemoveEvent(EventId id, Action<object[]> cb)
    {
        if (!eventList.ContainsKey(id)) return;
        if (eventList[id].Contains(cb)) eventList[id].Remove(cb);
        if (eventList[id].Count <= 0) eventList.Remove(id);
    }

    public static void RunEvent(EventId id, object[] objs = null)
    {
        if (!eventList.ContainsKey(id)) return;
        for (int i = 0; i < eventList[id].Count; i++)
        {
            eventList[id][i](objs);
        }
    }
}

public enum EventId
{
    OnClickObject,
    OnPointChanged,
    OnPositionChanged,
}