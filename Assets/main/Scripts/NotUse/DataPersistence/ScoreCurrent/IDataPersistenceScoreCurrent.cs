using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistenceScoreCurrent
{
    void LoadData(GameDataScoreCurrent dataScoreCurrent);
    void SaveData(ref GameDataScoreCurrent dataScoreCurrent);
}
