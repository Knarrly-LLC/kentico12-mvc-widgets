﻿using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.ImageCard.Model
{
    public class ImageCardWidgetProperties : IWidgetProperties
    {
        #region Properties
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Visible", Tooltip = "By enableing visible propertie we can view the widget data")]
        public bool Visible { get; set; } = true;
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Image Card Page Type*", Tooltip = "Please specifiy the ImageCard Page type code name. Ex: DancingGoatMvc.ImageCard. And this page type should contain these are fields(Image, Content and TargetUrl) are mandatory.")]
        [Required(ErrorMessage = "Please enter an image card page type class name")]
        public string ClassName { get; set; }
        [EditingComponent(PathSelector.IDENTIFIER, Order = 2, Label = "Path", Tooltip = "Please Select Image Card Path")]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        public IList<PathSelectorItem> Path { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "TopN", Tooltip = "Display latest Top N records")]
        [EditingComponentProperty("Size", 100)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string TopN { get; set; } = "4";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Order By", Tooltip = "Displays records based on given order.(ex:node id,node order)")]
        public string OrderBy { get; set; }
        #endregion
    }
}
