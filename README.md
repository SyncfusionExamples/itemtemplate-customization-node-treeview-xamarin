# How to customize TreeView ItemTemplate based on the node in Xamarin.Forms (SfTreeView)

You can customize the [TreeView](https://help.syncfusion.com/xamarin/treeview/overview?) [ItemTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~ItemTemplate.html?) based on the node by using [DataTemplateSelector](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/templates/data-templates/selector) in Xamarin.Forms.

You can  also refer the following article.

https://www.syncfusion.com/kb/11397/how-to-customize-treeview-itemtemplate-based-on-the-node-in-xamarin-forms-sftreeview

**XAML**

Binding ItemTemplateSelector to TreeView ItemTemplate.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:syncfusion="clr-namespace:Syncfusion.XForms.TreeView;assembly=Syncfusion.SfTreeView.XForms"
             xmlns:local="clr-namespace:TreeViewXamarin"
             x:Class="TreeViewXamarin.MainPage">
 
    <ContentPage.BindingContext>
        <local:FileManagerViewModel x:Name="viewModel"/>
    </ContentPage.BindingContext>
 
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:ItemTemplateSelector x:Key="ItemTemplateSelector" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <ContentPage.Content>
        <syncfusion:SfTreeView x:Name="treeView" Indentation="15" AutoExpandMode="AllNodesExpanded" ItemTemplateContextType="Node" 
                               ChildPropertyName="SubFiles" ItemsSource="{Binding ImageNodeInfo}" ItemTemplate="{StaticResource ItemTemplateSelector}"/>
 
    </ContentPage.Content>
</ContentPage>
```
**C#**

Apply template to node based on SubFiles.
``` c#
namespace TreeViewXamarin
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate _ParentTemplate { get; set; }
        public DataTemplate _ChildTemplate { get; set; }
        public ItemTemplateSelector()
        {
            this._ParentTemplate = new DataTemplate(typeof(ParentTemplate));
            this._ChildTemplate = new DataTemplate(typeof(ChildTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var node = item as TreeViewNode;
            var treeviewItem = node.Content as FileManager;
            if (treeviewItem == null)
                return null;
            if (treeviewItem.SubFiles!=null)
                return _ParentTemplate;
            else
                return _ChildTemplate;
        }
    }
}
```
**Output**

![ItenTemplateCustomization](https://github.com/SyncfusionExamples/itemtemplate-customization-node-treeview-xamarin/blob/master/ScreenShots/ItemTemplateCustomization.png)
