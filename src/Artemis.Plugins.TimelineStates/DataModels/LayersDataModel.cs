using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.TimelineStates.DataModels;

public class LayersDataModel : DataModel
{
    public LayersDataModel(ProfileConfiguration profileConfiguration)
    {
        profileConfiguration.Profile.ChildAdded += LayerAdded;        
        
        foreach (Layer layer in profileConfiguration.Profile.GetAllLayers())
        {
            AddDynamicChild(layer.EntityId.ToString(), new TimelineDataModel(layer), layer.Name);
        }
    }
    
    public void LayerAdded(object? sender, ProfileElementEventArgs e)
    {
        AddDynamicChild(e.ProfileElement.EntityId.ToString() , e.ProfileElement.Children, "list");
        
        
        //if (e.ProfileElement is Layer)
        //{
        //    //Layer layer = (Layer)e.ProfileElement;
        //    //AddDynamicChild(layer.EntityId.ToString(), new TimelineDataModel(layer), layer.Name);

        //}
    }

}   