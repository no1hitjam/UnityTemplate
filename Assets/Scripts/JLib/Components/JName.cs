using System.Collections.Generic;
using UnityEngine;

public class JName : MonoBehaviour
{
    private string _baseName = "";
    private int? _listIndex = null;

    public void SetBaseName(string baseName)
    {
        this._baseName = baseName;
        DisplayName();
    }

    public void SetListIndex(int? listIndex)
    {
        this._listIndex = listIndex;
        DisplayName();
    }

    private void DisplayName()
    {
        name = _baseName;
        if (_listIndex.HasValue) {
            name += " " + _listIndex;
        }
    }
}

