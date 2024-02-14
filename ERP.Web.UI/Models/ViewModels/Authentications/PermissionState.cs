namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class PermissionState
    {
        public string Name { get; set; }
        public CheckBoxValue Value { get; set; }

        public PermissionState(string name, bool isGranted)
        {
            Name = name;
            Value = string.IsNullOrEmpty(name) ? CheckBoxValue.Disabled : GetCheckBoxValue(isGranted);
        }

        private CheckBoxValue GetCheckBoxValue(bool isGranted)
        {
            return isGranted ? CheckBoxValue.Checked : CheckBoxValue.UnChecked;
        }
    }
}