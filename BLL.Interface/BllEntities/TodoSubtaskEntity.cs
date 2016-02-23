using System;

namespace BLL.Interface.BllEntities
{
    public class TodoSubtaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TodoTaskRefId { get; set; }
        public int StateRefId { get; set; }
    }
}
