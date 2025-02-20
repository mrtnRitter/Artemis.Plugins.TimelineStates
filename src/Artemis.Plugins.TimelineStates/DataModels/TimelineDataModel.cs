using Artemis.Core;
using Artemis.Core.Modules;
using System;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class TimelineDataModel : DataModel
{
    private readonly Layer _layer;

    public TimelineDataModel(Layer layer)
    {
        _layer = layer;

        AddDynamicChild("tl", layer.Timeline.Length, "Total Length");
        AddDynamicChild("ssl", layer.Timeline.StartSegmentLength, "Start Segment Length");

    }

};
