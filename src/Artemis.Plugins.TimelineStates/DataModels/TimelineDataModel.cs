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

        AddDynamicChild(layer.Timeline.Length.GetHashCode().ToString(), layer.Timeline.Length.Milliseconds, "Total Length");
        AddDynamicChild(layer.Timeline.StartSegmentLength.GetHashCode().ToString(), layer.Timeline.StartSegmentLength.Milliseconds, "Start Segment Length");

    }

};
