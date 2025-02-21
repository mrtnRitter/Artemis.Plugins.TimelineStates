using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class TimelineDataModel : DataModel
{
    public TimelineDataModel(Layer layer)
    {
        AddDynamicChild(layer.Timeline.Length.GetHashCode().ToString(), layer.Timeline.Length.TotalMilliseconds, "Total Length");
        AddDynamicChild(layer.Timeline.StartSegmentLength.GetHashCode().ToString(), layer.Timeline.StartSegmentLength.TotalMilliseconds, "Start Segment Length");
        AddDynamicChild(layer.Timeline.Position.GetHashCode().ToString(), layer.Timeline.Position.TotalMilliseconds, "Current Playhead Position");

    }

};
