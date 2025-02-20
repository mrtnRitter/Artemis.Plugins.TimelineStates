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


        





    //_profileCategory = profileCategory;
    //_profileCategory.ProfileConfigurationAdded += ProfileCategoryOnProfileConfigurationAdded;
    //_profileCategory.ProfileConfigurationRemoved += ProfileCategoryOnProfileConfigurationRemoved;

    //foreach (ProfileConfiguration profileConfiguration in _profileCategory.ProfileConfigurations)
    //    AddDynamicChild(profileConfiguration.ProfileId.ToString(), new ProfileConfigurationDataModel(profileConfiguration), profileConfiguration.Name);


    public void Dispose()
    {
    //    //_profilecategory.profileconfigurationadded -= profilecategoryonprofileconfigurationadded;
    //    //_profilecategory.profileconfigurationremoved -= profilecategoryonprofileconfigurationremoved;
    }

    //private void ProfileCategoryOnProfileConfigurationAdded(object? sender, ProfileConfigurationEventArgs e)
    //{
    //    AddDynamicChild(e.ProfileConfiguration.ProfileId.ToString(), new ProfileConfigurationDataModel(e.ProfileConfiguration), e.ProfileConfiguration.Name);
    //}

    //private void ProfileCategoryOnProfileConfigurationRemoved(object? sender, ProfileConfigurationEventArgs e)
    //{
    //    RemoveDynamicChildByKey(e.ProfileConfiguration.ProfileId.ToString());
    //}
}   