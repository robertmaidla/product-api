using System.Collections.Generic;

namespace ProductApi.Models
{
    public class GroupItem
    {
        public long Id { get; set; }
        public string name { get; set; }
        public long parentId { get; set; }
        public List<GroupItem> childGroups { get; set; }

        public GroupItem() {
            this.childGroups = new List<GroupItem>();
        }
    }
}