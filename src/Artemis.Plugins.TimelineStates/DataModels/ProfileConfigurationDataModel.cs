using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class ProfileConfigurationDataModel(ProfileConfiguration profileConfiguration) : DataModel
{
    private readonly ProfileConfiguration _profileConfiguration = profileConfiguration;

    public bool IsLoaded => _profileConfiguration.Profile != null;
    public bool IsSuspended => _profileConfiguration.IsSuspended;
    public bool ActivationConditionMet => _profileConfiguration.ActivationConditionMet;
    public string Profilename => _profileConfiguration.Profile.Name;

};
