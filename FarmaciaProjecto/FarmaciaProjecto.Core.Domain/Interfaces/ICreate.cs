using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Interfaces
{
    public interface ICreate<Entity>
    {
        Entity Create(Entity entity);

    }
}
