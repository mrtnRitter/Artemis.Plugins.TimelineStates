using System.Collections.Generic;
using System.Linq;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.TimelineStates.DataModels;

namespace Artemis.Plugins.TimelineStates;

public class TimelineStatesModule(IProfileService profileService) : Module<TimelineStatesDataModel>
{
    public override DataModelPropertyAttribute GetDataModelDescription()
    {
        return new DataModelPropertyAttribute
        {
            Name = "++Timeline States",
            Description = "Hopefully gives access to timeline states"
        };
    }

    private readonly IProfileService _profileService = profileService;


    public override List<IModuleActivationRequirement>? ActivationRequirements => null;

    public override void Enable()
    {
        _profileService.ProfileRemoved += ProfileRemoved;

        foreach (ProfileCategory profileCategory in _profileService.ProfileCategories)
            foreach (ProfileConfiguration profileConfiguration in profileCategory.ProfileConfigurations)
                DataModel.AddDynamicChild(profileConfiguration.ProfileId.ToString(), new LayersDataModel(profileConfiguration), profileConfiguration.Name);
    }

    public override void Disable()
    {
        _profileService.ProfileRemoved -= ProfileRemoved;

        List<LayersDataModel> dataModels = DataModel.DynamicChildren
            .Where(c => c.Value.BaseValue is LayersDataModel)
            .Select(c => c.Value.BaseValue)
            .Cast<LayersDataModel>()
            .ToList();
        DataModel.ClearDynamicChildren();
    }

    public override void Update(double deltaTime)
    {

    }

    private void ProfileRemoved(object? sender, ProfileConfigurationEventArgs e)
    {
        DataModel.RemoveDynamicChildByKey(e.ProfileConfiguration.ProfileId.ToString());
    }
}