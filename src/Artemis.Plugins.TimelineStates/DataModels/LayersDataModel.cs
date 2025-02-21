using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class LayersDataModel : DataModel
{
    private readonly ProfileConfiguration _profileConfiguration;

    public LayersDataModel(ProfileConfiguration profileConfiguration)
    {
        _profileConfiguration = profileConfiguration;

        foreach (Layer layer in _profileConfiguration.Profile.GetAllLayers())
        {
            AddDynamicChild(layer.EntityId.ToString(), new TimelineDataModel(layer), layer.Name);
        }
    }
}   