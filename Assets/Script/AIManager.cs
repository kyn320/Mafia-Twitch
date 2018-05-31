using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : Singleton<AIManager>
{

    public List<PlayerAI> aiList;

    public void AddAI(PlayerAI _ai)
    {
        aiList.Add(_ai);
    }

    public void ThinkAI(Context _context)
    {
        for (int i = 0; i < aiList.Count; ++i)
        {
            aiList[i].Think(_context);
        }
    }

}
