using System.Collections.Generic;
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

    public override List<IModuleActivationRequirement>? ActivationRequirements => null;

    public override void Enable()
    {
        profileService.ProfileRemoved += ProfileRemoved;
        profileService.ProfileCategoryRemoved += CategoryRemoved;

        foreach (ProfileCategory profileCategory in profileService.ProfileCategories)
            foreach (ProfileConfiguration profileConfiguration in profileCategory.ProfileConfigurations)
                DataModel.AddDynamicChild(profileConfiguration.ProfileId.ToString(), new LayersDataModel(profileConfiguration), profileConfiguration.Name);
    }

    public override void Disable()
    {
    }

    public override void Update(double deltaTime)
    {

    }

    private void ProfileRemoved(object? sender, ProfileConfigurationEventArgs e)
    {
        //DataModel.RemoveDynamicChildByKey(e.ProfileConfiguration.ProfileId.ToString());
        DataModel.ClearDynamicChildren();
    }

    private void CategoryRemoved (object? sender, ProfileCategoryEventArgs e)
    {
        DataModel.ClearDynamicChildren();
    }
}