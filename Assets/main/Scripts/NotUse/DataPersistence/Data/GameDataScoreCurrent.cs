using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class GameDataScoreCurrent
{
    public int diffiCult;
    public List<Stage> StageTime { get; set; }

    public GameDataScoreCurrent()
    {
        diffiCult = 0;
        StageTime = new List<Stage>() { };
    }
    public class Stage
    {
        public int Time { get; set; }
        public int StageLevel { get; set; }
        public Stage(int time, int stagelevel)
        {
            Time = time;
            StageLevel = stagelevel;
        }
    }
    public void StageTimeSave(int stageLevel, int stageTime)
    {
        var stage = StageTime.FirstOrDefault(e => e.StageLevel == stageLevel);
        if (stage == null)
        {
            StageTime.Add(new Stage(stageTime, stageLevel));
        }
        else
        {
            stage.Time = stageTime;
        }
    }
}
