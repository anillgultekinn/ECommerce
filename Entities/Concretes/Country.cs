﻿using Core.Entities;

namespace Entities.Concretes;

public class Country : Entity<Guid>
{
    public string Name { get; set; }

}