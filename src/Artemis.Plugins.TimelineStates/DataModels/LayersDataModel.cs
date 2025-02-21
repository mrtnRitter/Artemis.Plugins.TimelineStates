using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class LayersDataModel : DataModel
{
    private readonly ProfileConfiguration _profileConfiguration;

    public LayersDataModel(ProfileConfiguration profileConfiguration)
    {
        _profileConfiguration = profileConfiguration;

        _profileConfiguration.Profile.ChildAdded += layerAdded;
        _profileConfiguration.Profile.ChildRemoved += layerRemoved;


        foreach (Layer layer in _profileConfiguration.Profile.GetAllLayers())
        {
            AddDynamicChild(layer.EntityId.ToString(), new TimelineDataModel(layer), layer.Name);
        }
    }
    
    public void layerAdded(object? sender, ProfileElementEventArgs e)
    {
        foreach (Layer layer in _profileConfiguration.Profile.GetAllLayers())
        {
            AddDynamicChild(layer.EntityId.ToString(), new TimelineDataModel(layer), layer.Name);
        }
    }

    public void layerRemoved(object? sender, ProfileElementEventArgs e)
    {
        //RemoveDynamicChildByKey(e.Layer.EntityId.ToString());
    }

}   