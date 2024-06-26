using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible //interface = template
{
    public void Collect();
}

public interface IPickUps
{
    //Items itemScriptable { get; }

    Items Item { get; }
    string ItemName { get; }

    public void Collect();
}
