using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class ProfileConfigurationDataModel(ProfileConfiguration profileConfiguration) : DataModel
{
    private readonly ProfileConfiguration _profileConfiguration = profileConfiguration;
    public string Profilename => _profileConfiguration.Profile?.Name ?? "No Name";

    public System.Collections.Generic.List<Layer> Test => _profileConfiguration.Profile.GetAllLayers();
 
    //void listtl()
    //{
    //    foreach (Layer layer in Test)
    //        layer.Timeline.Length;
    //}
};
