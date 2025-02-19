﻿using System.Collections.Generic;
using System.Linq;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.TimelineStates.DataModels;

namespace Artemis.Plugins.TimelineStates;

public class TimelineStates(IProfileService profileService) : Module<TimelineDataModel>
{
    private readonly IProfileService _profileService = profileService;

    public override List<IModuleActivationRequirement>? ActivationRequirements => null;

    public override void Enable()
    {
        _profileService.ProfileCategoryAdded += ProfileServiceOnProfileCategoryAdded;
        _profileService.ProfileCategoryRemoved += ProfileServiceOnProfileCategoryRemoved;

        DataModel.AddDynamicChild("Title", "Profiles");


        foreach (ProfileCategory profileCategory in _profileService.ProfileCategories)
            foreach (ProfileConfiguration profileConfiguration in profileCategory.ProfileConfigurations)
                DataModel.AddDynamicChild(profileConfiguration.ProfileId.ToString(), new ProfileConfigurationDataModel(profileConfiguration), profileConfiguration.Name);


    }

    public override void Disable()
    {
        _profileService.ProfileCategoryAdded -= ProfileServiceOnProfileCategoryAdded;
        _profileService.ProfileCategoryRemoved -= ProfileServiceOnProfileCategoryRemoved;

        List<ProfileCategoryDataModel> dataModels = DataModel.DynamicChildren
            .Where(c => c.Value.BaseValue is ProfileCategoryDataModel)
            .Select(c => c.Value.BaseValue)
            .Cast<ProfileCategoryDataModel>()
            .ToList();
        DataModel.ClearDynamicChildren();
        foreach (ProfileCategoryDataModel profileCategoryDataModel in dataModels)
            profileCategoryDataModel.Dispose();
    }

    public override DataModelPropertyAttribute GetDataModelDescription()
    {
        return new DataModelPropertyAttribute
        {
            Name = "++Timeline States",
            Description = "Hopefully gives access to timeline states"
        };
    }

    public override void Update(double deltaTime)
    {
    }

    private void ProfileServiceOnProfileCategoryAdded(object? sender, ProfileCategoryEventArgs e)
    {
        DataModel.AddDynamicChild(e.ProfileCategory.EntityId.ToString(), new ProfileCategoryDataModel(e.ProfileCategory), e.ProfileCategory.Name);
    }

    private void ProfileServiceOnProfileCategoryRemoved(object? sender, ProfileCategoryEventArgs e)
    {
        DynamicChild<ProfileCategoryDataModel> dataModel = DataModel.GetDynamicChild<ProfileCategoryDataModel>(e.ProfileCategory.EntityId.ToString());
        DataModel.RemoveDynamicChild(dataModel);
        dataModel.Value.Dispose();
    }
}