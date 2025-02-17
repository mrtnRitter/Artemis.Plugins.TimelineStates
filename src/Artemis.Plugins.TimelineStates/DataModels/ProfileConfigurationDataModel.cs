using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class ProfileConfigurationDataModel(ProfileConfiguration profileConfiguration) : DataModel
{
    private readonly ProfileConfiguration _profileConfiguration = profileConfiguration;
    public string Profilename => _profileConfiguration.Profile?.Name ?? "No Name";

};
