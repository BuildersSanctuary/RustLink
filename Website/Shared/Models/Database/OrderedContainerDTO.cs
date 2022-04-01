using System.Collections.Generic;

namespace Website.Shared.Models.Database;

public class OrderedContainerDTO : IDTO
{
    public string Name { get; set; }
    
    public string Type { get; set; }
    
    public List<string> Items { get; set; }
}