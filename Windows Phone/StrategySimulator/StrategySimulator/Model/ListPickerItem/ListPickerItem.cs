
namespace StrategySimulator.Model.ListPickerItem
{
    public class ListPickerItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public ListPickerItem()
        {
        }
        public ListPickerItem(string name, string description, string displayName)
        {
            Name = name;
            Description = description;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
