using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace tech.project.Repository
{
  public interface IRepository<TModel> where TModel : IObjectContextAdapter, new()
  {
    TModel Model { get; }
    void Save();
  }
}