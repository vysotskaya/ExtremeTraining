using System;

namespace BLL.Interface.BllEntities
{
    public class TodoSubtaskEntity: BaseEntity
    {
        public string Name { get; set; }
        public int TodoTaskRefId { get; set; }
        public int StateRefId { get; set; }
    }
}
