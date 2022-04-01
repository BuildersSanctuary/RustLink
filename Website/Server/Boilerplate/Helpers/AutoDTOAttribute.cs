using System;

namespace Website.Server.Helpers;

public class AutoDTOAttribute : Attribute
{
    public Type DTO;
    
    public AutoDTOAttribute(Type DTO)
    {
        this.DTO = DTO;
    }
}